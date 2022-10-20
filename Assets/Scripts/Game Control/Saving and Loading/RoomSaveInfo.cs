using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSaveInfo
{
    public float x;
    public float y;
    public float z;

    public RoomType roomType;

    public ResourceRoomSave resourceRoom;
    public TimerRoomSave timerRoomSave;

    private GameObject room;

    public int roomNum;

    public RoomSaveInfo(Vector3 pos, RoomType type, ResourceRoomSave resourceRoom) {
        this.x = pos.x;
        this.y = pos.y;
        this.z = pos.z;
        this.roomType = type;
        this.resourceRoom = resourceRoom;
    }

    public RoomSaveInfo(Vector3 pos, RoomType type, TimerRoomSave timerRoomSave)
    {
        this.x = pos.x;
        this.y = pos.y;
        this.z = pos.z;
        this.roomType = type;
        this.timerRoomSave = timerRoomSave;
    }

    public RoomSaveInfo() {

    }

    public override string ToString()
    {
        return x + " " + y + " " + z;
    }

    public enum RoomType {
        ResourceRoom,
        TimedRoom,
        ArtifactRoom,
        StealingRoom
    }

    public void SetRoom(GameObject room) {
        this.room = room;
    }

    public GameObject getRoom() {
        return this.room;
    }

    public void RefreshInfo() {
        if (roomType == RoomType.ResourceRoom) {
            resourceRoom = room.GetComponent<ResourceRoom>().MakeCopy();
        }
        else if (roomType == RoomType.ArtifactRoom){
            timerRoomSave = room.GetComponent<ArtifactRoom>().MakeCopy();
        }
    }
}
