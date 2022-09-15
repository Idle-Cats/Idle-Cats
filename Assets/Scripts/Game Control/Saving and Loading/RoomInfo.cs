using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo
{
    public float x;
    public float y;
    public float z;

    public RoomType roomType;

    public ResourceRoomSave resourceRoom;

    private GameObject room;

    public RoomInfo(Vector3 pos, RoomType type, ResourceRoomSave resourceRoom) {
        this.x = pos.x;
        this.y = pos.y;
        this.z = pos.z;
        this.roomType = type;
        this.resourceRoom = resourceRoom;
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

    public void SetRoom(GameObject room) {
        this.room = room;
    }

    public void RefreshInfo() {
        resourceRoom = room.GetComponent<ResourceRoom>().MakeCopy();
    }
}
