using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MineralRoom : MonoBehaviour
{
    //looks good to me
    //skeleton class for resource rooms
    // Start is called before the first frame update

    public float roomInvent = 0;
    public float upgradeModifier = 0;
    public float roomCapacity = 0;
    public float resourceGen = 0;
    public string name = "Mineral Room";
    [SerializeField]
    private GameObject resourceCounter;
    public float globalMineral = 0; //TODO make this global

    void Start()
    {
        //initialise values here
        //temp placeholder code:
        this.name = "Mineral Room";
        this.roomCapacity = 100;
        this.resourceGen = 1;
        InvokeRepeating("updateRoom", 0.0f, 1.0f);

        //Alex code for loading in time
        //Michael please change this
        string dateQuitString = PlayerPrefs.GetString("dateQuit", "");
        if (!dateQuitString.Equals("")) {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;

            if (dateNow > dateQuit) {
                TimeSpan timeSpan = dateNow - dateQuit;
                addInvent((float)(this.resourceGen * timeSpan.TotalSeconds));
            }
        }
    }

    void OnApplicationQuit() {
        DateTime dateQuit = DateTime.Now;
        //Michael please change this
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString());
    }

    // Update is called once per frame
    void Update() //TODO change to once per second
    {
        //adds a tick of resource gen to roomInvent 
    }


    public void GetCopy(ResourceRoomSave resourceRoom) {
        this.roomInvent = resourceRoom.roomInvent;
        this.upgradeModifier = resourceRoom.upgradeModifier;
        this.roomCapacity = resourceRoom.roomCapacity;
        this.resourceGen = resourceRoom.resourceGen;
        this.name = resourceRoom.name;
        this.globalMineral = resourceRoom.globalResource;
    }

    public ResourceRoomSave MakeCopy() {
        return new ResourceRoomSave(roomInvent, upgradeModifier, roomCapacity, resourceGen, name, globalMineral);
    }

    //method for adding to invent making sure capacity isn't exceeded
    void addInvent(float x)
    {
        float tempInvent = roomInvent + x;
        if (tempInvent >= roomCapacity)
        {
            roomInvent = roomCapacity;
        }
        else
        {
            roomInvent = tempInvent;
        }
    }

    public void collectResources()
    {
            globalMineral = globalMineral + roomInvent;
            roomInvent = 0;
    }

    public void updateRoom()
    {
        if (roomInvent < roomCapacity)
        {
            addInvent(resourceGen * (1 + upgradeModifier));
        }

        resourceCounter.GetComponent<TextMeshProUGUI>().SetText("Current Resources: " + roomInvent + "/" + roomCapacity);
    }
}
