using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsFound : MonoBehaviour
{
    public Artifact[] allArtifacts;
    public Artifact[] unlockedArtifacts;
    public int unlockedArtifactsCount = 0;

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
}
