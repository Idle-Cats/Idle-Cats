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

    public HashSet<CatType> discoveredCats;

    public RoomSaveInfo[] rooms;
    public List<CatInfo> cats;

    public int catCount;

    public int roomCount;

    public int nodeLength;

    public float nodeY;

    public int[] unlockedArtifacts;
    public int unlockedArtifactCount;
    public ArtifactSaveInfo[] spawnedArtifacts;

    public DateTime timeSaved;

    public int highScore;
    public string userName;

    public int firstLoad;
    public int milestone1;
    public int milestone2;
    public int milestone3;
    public int milestone4;
    public int milestone5;
    public int milestone6;
    public int milestone7;
    public int milestone8;
    public int milestone9;
    public int milestone10;
    public int milestone11;
    public int milestone12;
    public int artifactTutorial;
}
