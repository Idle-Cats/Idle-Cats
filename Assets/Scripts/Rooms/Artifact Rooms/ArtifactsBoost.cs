using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsBoost : MonoBehaviour
{
    private Artifact artifact;

    public void Start()
    {
        artifact = gameObject.GetComponent<ArtifactDisplay>().artifact;
    }

    public void ApplyBoost() {
        if (artifact.boostType == Artifact.BoostType.resourceBoost) {
            if (gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInformation>().roomType == RoomSaveInfo.RoomType.ResourceRoom) {
                gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomBoost>().boostAmount += artifact.boost;
            }
        }
        else if (artifact.boostType == Artifact.BoostType.timedBoost) {
            if (gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInformation>().roomType == RoomSaveInfo.RoomType.ArtifactRoom) {
                gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomBoost>().boostAmount += artifact.boost;
            }
        }
    }

    public void RemoveBoost() {
        if (gameObject.GetComponent<CurrentRoom>().currentRoom != null) {
            if (artifact.boostType == Artifact.BoostType.resourceBoost) {
                if (gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInformation>().roomType == RoomSaveInfo.RoomType.ResourceRoom) {
                    gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomBoost>().boostAmount -= artifact.boost;
                }
            }
            else if (artifact.boostType == Artifact.BoostType.timedBoost) {
                if (gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInformation>().roomType == RoomSaveInfo.RoomType.ArtifactRoom) {
                    gameObject.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomBoost>().boostAmount -= artifact.boost;
                }
            }
        }
    }
}
