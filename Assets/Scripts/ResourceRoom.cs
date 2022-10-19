using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResourceRoom : MonoBehaviour
{
    //looks good to me
    //skeleton class for resource rooms
    // Start is called before the first frame update

        //TODO: adding buttons to increase the room inventory, add buttons to increase the number of rooms.
        /*
         * add a counter for amount of times room inventory has been upgraded.
         * add a counter for amount of times room generation has been upgraded.
         * button for inventupgrade, button for roomgen upgrade
         * Set text for each button based on roomtype, and what it currently costs.
         * currentcost based on each counter
         * make each button clickable if can afford
         * method for clicking button that will add to counter and remove resources.
        */

    public float roomInvent = 0;
    public RoomBoost roomBoost;
    //public float upgradeModifier = 0;
    public float roomCapacity = 0;
    public float resourceGen = 0;
    public new string name = "ResourceRoom";
    [SerializeField]
    private GameObject resourceCounter;

    //TODO make sure following variables work
    public int timesInventUpgraded = 0;
    public int timesGenerationUpgraded = 0;
    [SerializeField]
    private GameObject upgradeInventButtonText;
    [SerializeField]
    private GameObject upgradeInventButton;
    [SerializeField]
    private GameObject upgradeGenerationButtonText;
    [SerializeField]
    private GameObject upgradeGenerationButton;

    public ResourceType resourceType;

    void Start()
    {
        //initialise values here
        //temp placeholder code:
        this.name = "Fishing Room";
        this.roomCapacity = 1000;
        this.resourceGen = 1;
        InvokeRepeating("updateRoom", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update() //TODO change to once per second
    {
        //adds a tick of resource gen to roomInvent 
    }

    //Takes in save data of a room, and initialised the room with it.
    public void GetCopy(ResourceRoomSave resourceRoom) {
        this.roomInvent = resourceRoom.roomInvent;
        //this.upgradeModifier = resourceRoom.upgradeModifier;
        this.roomCapacity = resourceRoom.roomCapacity;
        this.resourceGen = resourceRoom.resourceGen;
        this.name = resourceRoom.name;
        this.roomBoost.boostAmount = resourceRoom.roomBoost;
        this.resourceType = resourceRoom.resourceType;
    }

    //makes a copy for saving
    public ResourceRoomSave MakeCopy() {
        return new ResourceRoomSave(roomInvent, roomBoost, roomCapacity, resourceGen, name, resourceType);
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

    //method that executes when collect button is pressed
    public void collectResources()
    {
        int roomInventRounded = (int)Math.Floor(roomInvent);
        if (resourceType == ResourceType.catpower) {
            gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().catPower += roomInventRounded;

        }
        else if (resourceType == ResourceType.minerals) {
            gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().minerals += roomInventRounded;
        }
        else if (resourceType == ResourceType.food) {
            gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().food += roomInventRounded;
        }

        roomInvent = roomInvent - roomInventRounded;

        resourceCounter.GetComponent<TextMeshProUGUI>().SetText("Current Resources: " + roomInvent + "/" + roomCapacity);
    }

    //this updates room every tick
    public void updateRoom()
    {
        if (roomInvent < roomCapacity)
        {
            addInvent(resourceGen * (1 + roomBoost.boostAmount));
        }

        resourceCounter.GetComponent<TextMeshProUGUI>().SetText("Current Resources: " + roomInvent + "/" + roomCapacity);
    }

    //enum for resourcetype
    public enum ResourceType {
        minerals,
        catpower,
        food
    }

    //method for calculating offline progress
    public void calculateOfflineProgress() {
        //Alex code for loading in time
        //Michael please change this
        DateTime dateQuit = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<SaveLoadManager>().infomation.timeSaved;
        DateTime dateNow = DateTime.Now;

        if (dateNow > dateQuit) {
            TimeSpan timeSpan = dateNow - dateQuit;
            addInvent((float)(Math.Floor(this.resourceGen * timeSpan.TotalSeconds)));
        }
    }

    //method for currentboost
    public float GetCurrentBoost() {
        return resourceGen * (1 + roomBoost.boostAmount);
    }

    //current costs are food = 400 catpower, mineral is 400 food, catpower is 400 mineral

    //following are methods associated with the two upgrade buttons:

    //formula for increasing the generation upgrade cost - TODO, adjust this.
    public int generationUpgradeCost()
    {
        int cost = (this.timesGenerationUpgraded+1) * (400);
        return cost;
    }
    //method for determining resource type of cost
    //public ResourceType costType()
    //{
    //}
}
