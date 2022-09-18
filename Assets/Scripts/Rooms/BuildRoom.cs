using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoom : MonoBehaviour
{
    public GameObject testRoom;
    public GameObject resourceRoom;
    public GameObject artifactRoom;

    public int roomCount = 0;

    public float roomHeight;

    public RoomInfo[] rooms = new RoomInfo[5];

    public GameObject catTest;

    void Start()
    {
        roomHeight = testRoom.GetComponent<SpriteRenderer>().size.y;
    }

    public void buildRoom (GameObject roomToBuild) {
        //Generates a room
        GameObject room = Instantiate(roomToBuild, gameObject.GetComponent<BuildingNodePlacer>().node.transform.position, Quaternion.identity);
        //room.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        //Sets the rooms room num to the room count for the cats to be loaded in
        room.GetComponent<RoomInfomation>().roomNum = roomCount;

        Vector3 pos = room.transform.position;
        //gets the info for the room, this is for saving and loading purposes as you cant save gameObjects
        if (room.GetComponent<RoomInfomation>().roomType == RoomInfo.RoomType.ResourceRoom) {
            RoomInfo roomInfo = new RoomInfo(pos, room.GetComponent<RoomInfomation>().roomType, room.GetComponent<ResourceRoom>().MakeCopy());
            roomInfo.SetRoom(room);

            //Holds an array of room info
            if (roomCount == rooms.Length - 1) {
                ExpandRooms();
            }
            rooms[roomCount] = roomInfo;
        }
        else {
            RoomInfo roomInfo = new RoomInfo(pos, room.GetComponent<RoomInfomation>().roomType, null);
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
        RoomInfo[] newRooms = new RoomInfo[rooms.Length * 4];

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
            if (rooms[i].roomType == RoomInfo.RoomType.ResourceRoom) {
                GameObject room = Instantiate(resourceRoom, new Vector3(rooms[i].x, rooms[i].y, rooms[i].z), Quaternion.identity);

                rooms[i].SetRoom(room);

                if (rooms[i].roomType == RoomInfo.RoomType.ResourceRoom) {
                    room.GetComponent<ResourceRoom>().GetCopy(rooms[i].resourceRoom);
                }
            }
            else if (rooms[i].roomType == RoomInfo.RoomType.ArtifactRoom) {
                GameObject room = Instantiate(artifactRoom, new Vector3(rooms[i].x, rooms[i].y, rooms[i].z), Quaternion.identity);

                rooms[i].SetRoom(room);

                if (rooms[i].roomType == RoomInfo.RoomType.ResourceRoom) {
                    room.GetComponent<ResourceRoom>().GetCopy(rooms[i].resourceRoom);
                }
            }
        }
    }

    public void RefreshRooms() {
        //refreshes room info, used just before saving to get up to date data
        for (int i = 0; i < roomCount; i++) {
            rooms[i].RefreshInfo();
        }
    }
}
