using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoostRooms : MonoBehaviour
{
    private Cat cat;

    public 

    void Start()
    {
        cat = GetComponent<Cat>();
    }

    public void ApplyCatBoost() {
        // cat null check
        if (cat == null) {
            return;
        }

        // current room null check
        CurrentRoom currentRoom = GetComponent<CurrentRoom>();
        if (currentRoom == null) {
            return;
        }

        // room info null check
        RoomInformation roomInfo = currentRoom.currentRoom.GetComponent<RoomInformation>();
        if(roomInfo == null || roomInfo.roomType != RoomSaveInfo.RoomType.ResourceRoom) {
            return;
        }

        // resource room null check
        ResourceRoom resourceRoom = currentRoom.currentRoom.GetComponent<ResourceRoom>();
        if (resourceRoom == null) {
            return;
        }

        // add the modifier to the resource room
        resourceRoom.roomBoost.boostAmount += Cat.GetSBoost(cat.catType);
        Debug.Log("Cat boost applied " + Cat.GetSBoost(cat.catType));

        // set boolean in RoomInformation to true linking the cat to the room
        roomInfo.containsCat = true;
    }

    public void RemoveCatBoost() {
        // cat null check
        if (cat == null) {
            return;
        }

        // current room null check
        CurrentRoom currentRoom = GetComponent<CurrentRoom>();
        if (currentRoom == null) {
            return;
        }

        // room info null check
        RoomInformation roomInfo = currentRoom.currentRoom.GetComponent<RoomInformation>();
        if(roomInfo == null || roomInfo.roomType != RoomSaveInfo.RoomType.ResourceRoom) {
            return;
        }

        // resource room null check
        ResourceRoom resourceRoom = currentRoom.currentRoom.GetComponent<ResourceRoom>();
        if (resourceRoom == null) {
            return;
        }

        // add the modifier to the resource room
        resourceRoom.roomBoost.boostAmount -= Cat.GetSBoost(cat.catType);
        Debug.Log("Cat boost Removed " + Cat.GetSBoost(cat.catType));
        roomInfo.containsCat = false;
    }
}
