using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CatList;

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

    public Artifact[] unlockedArtifacts;
}
