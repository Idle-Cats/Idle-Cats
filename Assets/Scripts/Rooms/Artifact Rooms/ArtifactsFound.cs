using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsFound : MonoBehaviour
{
    public Artifact[] allArtifacts;
    public Artifact[] unlockedArtifacts;
    public int unlockedArtifactsCount = 0;

    public GameObject[] spawnedArtifacts = new GameObject[5];
    public int artifactCount = 0;

    public GameObject artifactPrefab;

    private void Start()
    {
        unlockedArtifacts = new Artifact[allArtifacts.Length];
    }

    //Need to rewrite this code so it eventually upgrades artifacts to another type if you already have it
    public Artifact GetRandomArtifact() {
        if (unlockedArtifactsCount != allArtifacts.Length) {
            while (true) {
                Artifact artifact = allArtifacts[Random.Range(0, allArtifacts.Length)];
                if (!ArtifactAlreadyUnlocked(artifact)) {
                    unlockedArtifacts[unlockedArtifactsCount] = artifact;
                    unlockedArtifactsCount++;
                    return artifact;
                }

            }

        }
        else {
            return null;
        }
    }

    public bool ArtifactAlreadyUnlocked(Artifact artifact) {
        foreach (Artifact unlockedArtifact in unlockedArtifacts) {
            if (unlockedArtifact != null) {
                if (unlockedArtifact.Equals(artifact)) {
                    return true;
                }
            }
        }
        return false;
    }

    public void AddArtifact(GameObject artifact) {

        if (artifactCount == spawnedArtifacts.Length - 1) {
            ExpandArtifacts();
        }

        spawnedArtifacts[artifactCount] = artifact;

        artifactCount += 1;
    }

    private void ExpandArtifacts()
    {
        GameObject[] newArtifacts = new GameObject[spawnedArtifacts.Length * 4];

        for (int i = 0; i < artifactCount; i++) {
            newArtifacts[i] = spawnedArtifacts[i];
        }

        spawnedArtifacts = newArtifacts;
    }

    public void loadSaveInfo(ArtifactSaveInfo[] saveFile)
    {
        spawnedArtifacts = new GameObject[saveFile.Length];
        for (int i = 0; i < saveFile.Length; i++) {
            GameObject newArtifact = Instantiate(artifactPrefab, new Vector2(saveFile[i].x, saveFile[i].y), Quaternion.identity);
            newArtifact.GetComponent<ArtifactDisplay>().artifact = saveFile[i].artifact;
            newArtifact.GetComponent<ArtifactDisplay>().RefreshSelf();
            newArtifact.GetComponent<CurrentRoom>().currentRoom = gameObject.GetComponent<BuildRoom>().rooms[saveFile[i].roomNum].getRoom();
        }
    }
}
