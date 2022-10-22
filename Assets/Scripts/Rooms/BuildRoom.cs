using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildRoom : MonoBehaviour
{
    public GameObject testRoom;
    public GameObject resourceRoom;
    public GameObject artifactRoom;
    public GameObject StealingRoom;
    public GameObject excavationRoom;

    public int roomCount = 0;

    public float roomHeight;

    public RoomSaveInfo[] rooms = new RoomSaveInfo[5];

    public GameObject catTest;

    [SerializeField]
    private List<GameObject> buildButtonList;

    CatGameFlags flags;

    public Sprite mineralImage;
    public Sprite catPowerImage;
    public Sprite foodImage;

    public BuildingNodePlacer buildingNodePlacer;
    public bool gameStarted = false;

    public Queue<GameObject> emptyRooms = new Queue<GameObject>();


    void Start()
    {
        roomHeight = testRoom.GetComponent<SpriteRenderer>().size.y;
        flags = gameObject.GetComponent<CatGameFlags>();
    }

    void Update()
    {
        canAffordPrices();

        if (gameStarted) {
            if (gameObject.GetComponent<User>().roomDepth == 0)
            {
                GameObject room = buildExcavationRoom(excavationRoom);
                room.GetComponent<RoomExcavation>().Start();
                room.GetComponent<RoomExcavation>().clickCollect();
            }

            gameStarted = false;
        }
    }

    public GameObject buildExcavationRoom(GameObject roomToBuild)
    {
        //Generates a room
        GameObject room = Instantiate(roomToBuild, new Vector2(0, -1.6f), Quaternion.identity);
        //room.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        //Sets the rooms room num to the room count for the cats to be loaded in
        room.GetComponent<RoomInformation>().roomNum = roomCount;
        room.GetComponent<RoomInformation>().gameControl = gameObject;

        Vector3 pos = room.transform.position;
        //gets the info for the room, this is for saving and loading purposes as you cant save gameObjects
        if (room.GetComponent<RoomInformation>().roomType == RoomSaveInfo.RoomType.ResourceRoom) {
            RoomSaveInfo roomInfo = new RoomSaveInfo(pos, room.GetComponent<RoomInformation>().roomType, room.GetComponent<ResourceRoom>().MakeCopy());
            roomInfo.SetRoom(room);

            //Holds an array of room info
            Debug.Log("Room Length: " + rooms);
            if (roomCount == rooms.Length - 1)
            {
                ExpandRooms();
            }
            rooms[roomCount] = roomInfo;
        } else if (room.GetComponent<RoomInformation>().roomType == RoomSaveInfo.RoomType.ArtifactRoom) {
            RoomSaveInfo roomInfo = new RoomSaveInfo(pos, room.GetComponent<RoomInformation>().roomType, room.GetComponent<ArtifactRoom>().MakeCopy());
            
            roomInfo.SetRoom(room);

            //Holds an array of room info
            if (roomCount == rooms.Length - 1)
            {
                ExpandRooms();
            }
            rooms[roomCount] = roomInfo;
        }

        return room;
    }

    public void buildRoomInEmptyRoom(GameObject roomToBuild)
    {
        //Generates a room
        GameObject emptyRoom = emptyRooms.Dequeue();
        GameObject room = Instantiate(roomToBuild, emptyRoom.transform.position, Quaternion.identity);

        //Be careful with this function it is scary
        Destroy(emptyRoom);

        //room.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        //Sets the rooms room num to the room count for the cats to be loaded in
        room.GetComponent<RoomInformation>().roomNum = roomCount;
        room.GetComponent<RoomInformation>().gameControl = gameObject;

        Vector3 pos = room.transform.position;
        //gets the info for the room, this is for saving and loading purposes as you cant save gameObjects
        if (room.GetComponent<RoomInformation>().roomType == RoomSaveInfo.RoomType.ResourceRoom)
        {
            RoomSaveInfo roomInfo = new RoomSaveInfo(pos, room.GetComponent<RoomInformation>().roomType, room.GetComponent<ResourceRoom>().MakeCopy());
            roomInfo.SetRoom(room);

            //Holds an array of room info
            Debug.Log("Room Length: " + rooms);
            if (roomCount == rooms.Length - 1)
            {
                ExpandRooms();
            }
            rooms[roomCount] = roomInfo;
        }
        else if (room.GetComponent<RoomInformation>().roomType == RoomSaveInfo.RoomType.ArtifactRoom)
        {
            RoomSaveInfo roomInfo = new RoomSaveInfo(pos, room.GetComponent<RoomInformation>().roomType, room.GetComponent<ArtifactRoom>().MakeCopy());

            roomInfo.SetRoom(room);

            //Holds an array of room info
            if (roomCount == rooms.Length - 1)
            {
                ExpandRooms();
            }
            rooms[roomCount] = roomInfo;
        }

        roomCount++;
    }

    private void ExpandRooms()
    {
        RoomSaveInfo[] newRooms = new RoomSaveInfo[rooms.Length * 4];

        for (int i = 0; i < roomCount; i++)
        {
            newRooms[i] = rooms[i];
        }

        rooms = newRooms;
    }

    private string PrintRooms()
    {
        string strings = "";

        for (int i = 0; i < roomCount + 1; i++)
        {
            strings += rooms[i] + "\n";
        }

        return strings;
    }

    public void LoadRooms()
    {
        //Loads rooms using room info
        buildingNodePlacer.nodeLength = -1;
        buildingNodePlacer.placeNode();
        for (int i = 0; i < roomCount; i++)
        {
            if (rooms[i].roomType == RoomSaveInfo.RoomType.ResourceRoom)
            {
                GameObject room = Instantiate(resourceRoom, new Vector3(rooms[i].x, rooms[i].y, rooms[i].z), Quaternion.identity);

                room.GetComponent<RoomInformation>().gameControl = gameObject;
                rooms[i].SetRoom(room);
                room.GetComponent<ResourceRoom>().GetCopy(rooms[i].resourceRoom);
                room.GetComponent<ResourceRoom>().calculateOfflineProgress();

                ResourceRoom roomResourceRoom = room.GetComponent<ResourceRoom>();

                if (roomResourceRoom.resourceType == ResourceRoom.ResourceType.minerals) {
                    room.GetComponent<SpriteRenderer>().sprite = mineralImage;
                }
                else if (roomResourceRoom.resourceType == ResourceRoom.ResourceType.catpower) {
                    room.GetComponent<SpriteRenderer>().sprite = catPowerImage;
                }
                else if (roomResourceRoom.resourceType == ResourceRoom.ResourceType.food) {
                    room.GetComponent<SpriteRenderer>().sprite = foodImage;
                }
            }
            else if (rooms[i].roomType == RoomSaveInfo.RoomType.ArtifactRoom)
            {
                GameObject room = Instantiate(artifactRoom, new Vector3(rooms[i].x, rooms[i].y, rooms[i].z), Quaternion.identity);

                room.GetComponent<RoomInformation>().gameControl = gameObject;

                rooms[i].SetRoom(room);

                room.GetComponent<ArtifactRoom>().GetCopy(rooms[i].timerRoomSave);
                room.GetComponent<ArtifactRoom>().calculateOfflineProgress();
            }
        }
    }

    public void RefreshRooms()
    {
        //refreshes room info, used just before saving to get up to date data
        for (int i = 0; i < roomCount; i++)
        {
            rooms[i].RefreshInfo();
        }
    }

    public void canAffordPrices()
    {
        foreach (GameObject room in buildButtonList)
        {
            bool resourceRoom = false;
            if (room.gameObject.GetComponent<CanAfford>().roomType == RoomSaveInfo.RoomType.ResourceRoom)
            {
                //Update price
                //Room cost:
                /*
                $0 for first room then:
                base cost * 2 ^ (number of rooms / 5)

                Upgrade Room Levelling Algorithms:
                capacity = level * original capacity
                resource generation = resource generation * 2 ^ (level / 2)
                */

                int currentPrice = 0;

                currentPrice = (room.GetComponent<CanAfford>().basePrice * 2 * 2 ^ (roomCount / 5));

                if (roomCount == 0 && room.gameObject.GetComponent<CanAfford>().resourceType == ResourceRoom.ResourceType.catpower) {
                    currentPrice = 0;
                }

                room.GetComponent<CanAfford>().currentPrice = currentPrice;
                resourceRoom = true;
            }
            

            int price = room.GetComponent<CanAfford>().currentPrice;
            CanAfford.PriceType priceType = room.GetComponent<CanAfford>().priceType;


            string buttonText = "";
            buttonText += room.name + "\nPrice: " + price + " " + priceType;
            room.GetComponent<ButtonSetText>().SetText(buttonText);

            if (EmptyRoomAvailable()) {
                if (priceType == CanAfford.PriceType.Minerals) {
                    if (gameObject.GetComponent<User>().minerals >= price) {
                        if (flags.resourcesCanBeClicked) {
                            room.GetComponent<Button>().interactable = true;
                        }
                        else {
                            if (!resourceRoom) {
                                room.GetComponent<Button>().interactable = true;
                            }
                            else {
                                room.GetComponent<Button>().interactable = false;
                            }
                        }
                    }
                    else {
                        room.GetComponent<Button>().interactable = false;
                    }
                }
                else if (priceType == CanAfford.PriceType.Catpower) {
                    if (gameObject.GetComponent<User>().catPower >= price && flags.resourcesCanBeClicked) {
                        room.GetComponent<Button>().interactable = true;
                    }
                    else {
                        room.GetComponent<Button>().interactable = false;
                    }
                }
                else if (priceType == CanAfford.PriceType.Food) {
                    if (gameObject.GetComponent<User>().food >= price && flags.resourcesCanBeClicked) {
                        room.GetComponent<Button>().interactable = true;
                    }
                    else {
                        room.GetComponent<Button>().interactable = false;
                    }
                }
            }
            else {
                room.GetComponent<Button>().interactable = false;
            }
        }
    }

    public bool EmptyRoomAvailable() {
        if (emptyRooms.Count > 0) {
            return true;
        }
        else {
            return false;
        }
    }
}
