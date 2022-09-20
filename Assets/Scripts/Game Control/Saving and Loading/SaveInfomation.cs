using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CatList;
using System;

public class SaveInfomation
{
    //holds all infomation to be saved
    public int food = 0;
    public int minerals = 0;
    public int catPower = 0;

    public HashSet<Cats> discoveredCats;

    public RoomSaveInfo[] rooms;
    public CatInfo[] cats;

    public int catCount;

    public int roomCount;

    public int nodeLength;

    public float nodeY;

    public int[] unlockedArtifacts;
    public int unlockedArtifactCount;
    public ArtifactSaveInfo[] spawnedArtifacts;

    public DateTime timeSaved;
}
