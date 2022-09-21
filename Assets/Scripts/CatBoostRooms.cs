using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoostRooms : MonoBehaviour
{
    private Cat cat;

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
        RoomInfomation roomInfo = currentRoom.currentRoom.GetComponent<RoomInfomation>();
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
        Debug.Log("Cat boost applied" + Cat.GetSBoost(cat.catType));

        // if (gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInfomation>().roomType == RoomSaveInfo.RoomType.ResourceRoom) {
        //     gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<ResourceRoom>().upgradeModifier += Cats.GetSBoost(cat.GetCatType());
        //     Debug.Log("Cat boost applied" + Cats.GetSBoost(cat.GetCatType()));
        // }
    }

    // public void RemoveCatBoost() {
    //     if (gameObject.GetComponent<CurrentRoom>().currentRoom != null) {
    //         if (gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInfomation>().roomType == RoomSaveInfo.RoomType.ResourceRoom) {
    //             gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<ResourceRoom>().upgradeModifier -= gameObject.GetComponent<ArtifactDisplay>().artifact.boost;
    //         }
    //     }
    // }
}
