using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildRoom : MonoBehaviour
{
    public GameObject testRoom;
    public GameObject resourceRoom;
    public GameObject artifactRoom;

    public int roomCount = 0;

    public float roomHeight;

    public RoomSaveInfo[] rooms = new RoomSaveInfo[5];

    public GameObject catTest;

    [SerializeField]
    private List<GameObject> buildButtonList;

    void Start()
    {
        roomHeight = testRoom.GetComponent<SpriteRenderer>().size.y;
    }

    void Update()
    {
        canAffordPrices();
    }

    public void buildRoom (GameObject roomToBuild) {
        //Generates a room
        GameObject room = Instantiate(roomToBuild, gameObject.GetComponent<BuildingNodePlacer>().node.transform.position, Quaternion.identity);
        //room.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        //Sets the rooms room num to the room count for the cats to be loaded in
        room.GetComponent<RoomInfomation>().roomNum = roomCount;
        room.GetComponent<RoomInfomation>().gameControl = gameObject;

        Vector3 pos = room.transform.position;
        //gets the info for the room, this is for saving and loading purposes as you cant save gameObjects
        if (room.GetComponent<RoomInfomation>().roomType == RoomSaveInfo.RoomType.ResourceRoom) {
            RoomSaveInfo roomInfo = new RoomSaveInfo(pos, room.GetComponent<RoomInfomation>().roomType, room.GetComponent<ResourceRoom>().MakeCopy());
            roomInfo.SetRoom(room);

            //Holds an array of room info
            if (roomCount == rooms.Length - 1) {
                ExpandRooms();
            }
            rooms[roomCount] = roomInfo;
        }
        else if (room.GetComponent<RoomInfomation>().roomType == RoomSaveInfo.RoomType.ArtifactRoom) {
            RoomSaveInfo roomInfo = new RoomSaveInfo(pos, room.GetComponent<RoomInfomation>().roomType, room.GetComponent<ArtifactRoom>().MakeCopy());
            roomInfo.SetRoom(room);

            //Holds an array of room info
            if (roomCount == rooms.Length - 1) {
                ExpandRooms();
            }
            rooms[roomCount] = roomInfo;
        }

        roomCount++;

        gameObject.GetComponent<BuildingNodePlacer>().placeNode();

    }

    private void ExpandRooms() {
        RoomSaveInfo[] newRooms = new RoomSaveInfo[rooms.Length * 4];

        for (int i = 0; i < roomCount; i++) {
            newRooms[i] = rooms[i];
        }

        rooms = newRooms;
    }

    private string PrintRooms() {
        string strings = "";

        for (int i = 0; i < roomCount + 1; i++) {
            strings += rooms[i] + "\n";
        }

        return strings;
    }

    public void LoadRooms() {
        //Loads rooms using room info
        gameObject.GetComponent<BuildingNodePlacer>().nodeLength = 0;
        for (int i = 0; i < roomCount; i++) {
            if (rooms[i].roomType == RoomSaveInfo.RoomType.ResourceRoom) {
                GameObject room = Instantiate(resourceRoom, new Vector3(rooms[i].x, rooms[i].y, rooms[i].z), Quaternion.identity);

                room.GetComponent<RoomInfomation>().gameControl = gameObject;
                rooms[i].SetRoom(room);
                room.GetComponent<ResourceRoom>().GetCopy(rooms[i].resourceRoom);
                room.GetComponent<ResourceRoom>().calculateOfflineProgress();
            }
            else if (rooms[i].roomType == RoomSaveInfo.RoomType.ArtifactRoom) {
                GameObject room = Instantiate(artifactRoom, new Vector3(rooms[i].x, rooms[i].y, rooms[i].z), Quaternion.identity);

                room.GetComponent<RoomInfomation>().gameControl = gameObject;

                rooms[i].SetRoom(room);

                room.GetComponent<ArtifactRoom>().GetCopy(rooms[i].timerRoomSave);
                room.GetComponent<ArtifactRoom>().calculateOfflineProgress();
            }
        }
    }

    public void RefreshRooms() {
        //refreshes room info, used just before saving to get up to date data
        for (int i = 0; i < roomCount; i++) {
            rooms[i].RefreshInfo();
        }
    }

    public void canAffordPrices() {
        foreach(GameObject room in buildButtonList){
            if (room.gameObject.GetComponent<RoomInfomation>().roomType == RoomSaveInfo.RoomType.ResourceRoom) {
                //Update price
            }

            int price = room.GetComponent<CanAfford>().price;
            CanAfford.PriceType priceType = room.GetComponent<CanAfford>().priceType;

            if (priceType == CanAfford.PriceType.Minerals) {
                if (gameObject.GetComponent<User>().minerals >= price) {
                    room.GetComponent<Button>().interactable = true;
                }
                else {
                    room.GetComponent<Button>().interactable = false;
                }
            }
            else if (priceType == CanAfford.PriceType.Catpower) {
                if (gameObject.GetComponent<User>().catPower >= price) {
                    room.GetComponent<Button>().interactable = true;
                }
                else {
                    room.GetComponent<Button>().interactable = false;
                }
            }
            else if (priceType == CanAfford.PriceType.Food) {
                if (gameObject.GetComponent<User>().food >= price) {
                    room.GetComponent<Button>().interactable = true;
                }
                else {
                    room.GetComponent<Button>().interactable = false;
                }
            }
        }
    }
}
