using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactSaveInfo
{
    public float x;
    public float y;
    public float z;

    public int artifactNum;

    public int roomNum;

    public ArtifactSaveInfo()
    {

    }

    public ArtifactSaveInfo(GameObject artifact, int artifactNum) {
        this.x = artifact.transform.position.x;
        this.y = artifact.transform.position.y;
        this.z = artifact.transform.position.z;

        this.artifactNum = artifactNum;

        this.roomNum = artifact.GetComponent<CurrentRoom>().currentRoom.GetComponent<RoomInformation>().roomNum;
    }

    public ArtifactSaveInfo[] makeSaveInfo(GameObject[] artifacts, int length, Artifact[] allArtifacts) {
        ArtifactSaveInfo[] tempSave = new ArtifactSaveInfo[length];
        for (int i = 0; i < length; i++) {
            tempSave[i] = new ArtifactSaveInfo(artifacts[i], findNum(artifacts[i], allArtifacts));
        }

        return tempSave;
    }

    private int findNum(GameObject artifact, Artifact[] listOfArtifacts) {
        for (int i = 0; i < listOfArtifacts.Length; i++) {
            if (artifact.GetComponent<ArtifactDisplay>().artifact == listOfArtifacts[i]) {
                return i;
            }
        }
        return -1;
    }
}
