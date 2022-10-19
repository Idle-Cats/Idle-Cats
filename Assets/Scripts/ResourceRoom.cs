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
         * finish update method
         * Add a UI button for inventupgrade, button for roomgen upgrade
         * Set text for each button based on roomtype, and what it currently costs.
         * make each button clickable if can afford
         * implement counters into calculations
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
    void Update() 
    {
        // if canAffordUpgrade(true) set upgradeGenerationButton.isInteractable(true);
        // if canAffordUpgrade(false) set upgradeInventButton.isInteractable(true);
        
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
            addInvent((resourceGen * (timesGenerationUpgraded + 1)) * (1 + roomBoost.boostAmount));
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
        int cost = (timesGenerationUpgraded + 1) * (400);
        return cost;
    }

    //method for increasing the invent upgrade cost - TODO, adjust this

        public int inventUpgradeCost()
    {
        int cost = (((timesInventUpgraded + 1) * (timesInventUpgraded+1)) * 1000);
        return cost;
    }

    //method for determining resource type of cost
    public ResourceType costResourceType()
    {
        if (resourceType == ResourceType.food)
        {
            return ResourceType.catpower;
        }
        else if (resourceType == ResourceType.minerals)
        {
            return ResourceType.food;
        }
        else
        {
            return ResourceType.minerals;
        }
    }

    //method for determining if user can afford an upgrade
    //takes in a bool to determine which button - true = generation, false = inventory
    public bool canAffordUpgrade(bool generateButton)
    {
        ResourceType costType = costResourceType();

        if (generateButton)
        {
            if (costType == ResourceType.catpower)
            {
                if (gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().catPower >= generationUpgradeCost())
                {
                    return true;
                }
                return false;
            }
            else if (costType == ResourceType.minerals)
            {
                if (gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().minerals >= generationUpgradeCost())
                {
                    return true;
                }
                return false;
            }
            else if (resourceType == ResourceType.food)
            {
                if (gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().food >= generationUpgradeCost())
                {
                    return true;
                }
                return false;
            }
            else return false;
        }
        else
        {
            if (costType == ResourceType.catpower)
            {
                if (gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().catPower >= inventUpgradeCost())
                {
                    return true;
                }
                return false;
            }
            else if (costType == ResourceType.minerals)
            {
                if (gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().minerals >= inventUpgradeCost())
                {
                    return true;
                }
                return false;
            }
            else if (resourceType == ResourceType.food)
            {
                if (gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().food >= inventUpgradeCost())
                {
                    return true;
                }
                return false;
            }
            else return false;
        }
    }

    //method for if upgradegenerationbutton is pressed
    public void upgradeGenerationButtonPress()
    {
        int cost = generationUpgradeCost();
        ResourceType type = costResourceType();
        removeResources(cost, type);
        timesGenerationUpgraded++;
    }

    //method for if upgrade invent button is pressed
    public void upgradeInventButtonPress()
    {
        int cost = generationUpgradeCost();
        ResourceType type = costResourceType();
        removeResources(cost, type);
        timesInventUpgraded++;
        roomCapacity = (1000 * (timesInventUpgraded + 1));
    }

    //method for removing resources from player
    public void removeResources(int cost, ResourceType resource)
    {
        if (resource == ResourceType.catpower)
        {
            gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().catPower -= cost;

        }
        else if (resource == ResourceType.minerals)
        {
            gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().minerals -= cost;
        }
        else if (resource == ResourceType.food)
        {
            gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().food -= cost;
        }
    }
}
