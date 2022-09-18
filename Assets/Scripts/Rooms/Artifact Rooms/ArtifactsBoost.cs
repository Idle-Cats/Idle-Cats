using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsBoost : MonoBehaviour
{
    public void ApplyBoost() {
        if (gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInfomation>().roomType == RoomSaveInfo.RoomType.ResourceRoom) {
            gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<ResourceRoom>().upgradeModifier += gameObject.GetComponent<ArtifactDisplay>().artifact.boost;
        }
    }

    public void RemoveBoost() {
        if (gameObject.GetComponent<CurrentRoom>().currentRoom != null) {
            if (gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInfomation>().roomType == RoomSaveInfo.RoomType.ResourceRoom) {
                gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<ResourceRoom>().upgradeModifier -= gameObject.GetComponent<ArtifactDisplay>().artifact.boost;
            }
        }
    }
}
