using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoom : MonoBehaviour
{
    public GameObject testRoom;

    public int roomCount = 0;

    public float roomHeight;

    public RoomInfo[] rooms = new RoomInfo[5];

    public GameObject catTest;

    void Start()
    {
        roomHeight = testRoom.GetComponent<SpriteRenderer>().size.y;
    }

    public void placeTestRoom() {
        GameObject room = Instantiate(testRoom, gameObject.GetComponent<BuildingNodePlacer>().node.transform.position, Quaternion.identity);
        room.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

        if (roomCount == 0) {
            GameObject cat = Instantiate(catTest, room.transform.position, Quaternion.identity);
            cat.GetComponent<CurrentRoom>().currentRoom = room;
        }//remove this code later just for cat testing purposes

        roomCount++;

        gameObject.GetComponent<BuildingNodePlacer>().placeNode();
        Vector3 pos = room.transform.position;

        RoomInfo roomInfo = new RoomInfo(pos, RoomInfo.RoomType.ResourceRoom);

        if (rooms.Length == roomCount) {
            ExpandRooms();
        }
        rooms[roomCount] = roomInfo;
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
}
