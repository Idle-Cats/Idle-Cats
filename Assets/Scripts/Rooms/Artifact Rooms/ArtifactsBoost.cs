using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsBoost : MonoBehaviour
{
    public void ApplyBoost() {
        if (gameObject.GetComponent<CurrentRoom>().GetComponent<RoomInfomation>().roomType == RoomInfo.RoomType.ResourceRoom) {
            gameObject.GetComponent<CurrentRoom>().GetComponent<ResourceRoom>().upgradeModifier += gameObject.GetComponent<ArtifactDisplay>().artifact.boost;
        }
    }

    public void RemoveBoost() {

    }
}
