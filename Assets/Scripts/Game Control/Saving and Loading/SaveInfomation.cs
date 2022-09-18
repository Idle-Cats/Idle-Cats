using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CatList;

public class SaveInfomation
{
    //holds all infomation to be saved
    public int money = 243564;

    public int cheese = 1982810;

    public HashSet<Cats> discoveredCats;

    public RoomSaveInfo[] rooms;
    public CatInfo[] cats;

    public int catCount;

    public int roomCount;

    public int nodeLength;

    public float nodeY;
}
