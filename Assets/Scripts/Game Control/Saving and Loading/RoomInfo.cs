using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo
{
    public float x;
    public float y;
    public float z;

    public RoomType roomType;

    public RoomInfo(Vector3 pos, RoomType type) {
        this.x = pos.x;
        this.y = pos.y;
        this.z = pos.z;
        this.roomType = type;
    }

    public RoomInfo() {

    }

    public override string ToString()
    {
        return x + " " + y + " " + z;
    }

    public enum RoomType {
        ResourceRoom,
        TimedRoom
    }
}
