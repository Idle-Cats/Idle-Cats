using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInfo
{
    public float x;
    public float y;
    public float z;

    public int roomNum;

    public CatInfo() {

    }

    public CatInfo(GameObject cat) {
        x = cat.transform.position.x;
        y = cat.transform.position.y;
        z = cat.transform.position.z;

        this.roomNum = cat.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInformation>().roomNum;
    }
}
