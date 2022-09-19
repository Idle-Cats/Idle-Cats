using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactSaveInfo
{
    public float x;
    public float y;
    public float z;

    public Artifact artifact;

    public int roomNum;

    public ArtifactSaveInfo()
    {

    }

    public ArtifactSaveInfo(GameObject artifact) {
        this.x = artifact.transform.position.x;
        this.y = artifact.transform.position.y;
        this.z = artifact.transform.position.z;

        this.artifact = artifact.GetComponent<ArtifactDisplay>().artifact;

        this.roomNum = artifact.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInfomation>().roomNum;
    }

    public ArtifactSaveInfo[] makeSaveInfo(GameObject[] artifacts, int length) {
        ArtifactSaveInfo[] tempSave = new ArtifactSaveInfo[length];
        for (int i = 0; i < length; i++) {
            tempSave[i] = new ArtifactSaveInfo(artifacts[i]);
        }

        return tempSave;
    }
}
