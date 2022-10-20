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
         * add UI for each button texts
         * make each button clickable if can afford see update method
         * 
         * save the text of buttons rememeber
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
    private Button upgradeInventButton;
    [SerializeField]
    private GameObject upgradeGenerationButtonText;
    [SerializeField]
    private Button upgradeGenerationButton;
    [SerializeField]
    private GameObject roomInfoText;

    public ResourceType resourceType;

    void Start()
    {
        //initialise values here
        //temp placeholder code:
        this.name = "Fishing Room";
        this.roomCapacity = 1000;
        this.resourceGen = 1;
        InvokeRepeating("updateRoom", 0.0f, 1.0f);
        upgradeGenerationButtonText.GetComponent<TextMeshProUGUI>().SetText(updateButtonText(true));
        upgradeInventButtonText.GetComponent<TextMeshProUGUI>().SetText(updateButtonText(false));
        setRoomInfo();

    }

    // Update is called once per frame
    void Update() 
    {
        //change state of buttons.
        if (canAffordUpgrade(true))
        {
            upgradeGenerationButton.interactable = true;
        }
        else
        {
            upgradeGenerationButton.interactable = false;
        }

        if (canAffordUpgrade(false))
        {
            upgradeInventButton.interactable = true;
        }
        else
        {
            upgradeInventButton.interactable = false;
        }
        
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
        upgradeGenerationButtonText.GetComponent<TextMeshProUGUI>().SetText(updateButtonText(true));
        setRoomInfo();
    }

    //method for if upgrade invent button is pressed
    public void upgradeInventButtonPress()
    {
        int cost = generationUpgradeCost();
        ResourceType type = costResourceType();
        removeResources(cost, type);
        timesInventUpgraded++;
        roomCapacity = (1000 * (timesInventUpgraded + 1));
        upgradeInventButtonText.GetComponent<TextMeshProUGUI>().SetText(updateButtonText(false));
        setRoomInfo();
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
    //method for putting Resourcetype to string
    public string resourceToString(ResourceType resource)
    {
        if (resource == ResourceType.catpower)
        {
            return "CatPower";
        }
        else if (resource == ResourceType.minerals)
        {
            return "Minerals";
        }
        else if (resource == ResourceType.food)
        {
            return "Food";
        }
        else return "Error";
    }

    //method for updating button text:
    public string updateButtonText(bool generateButton)
    {
        if (generateButton)
        {
            if (resourceType == ResourceType.catpower)
            {
                return "Buy more cardboard boxes?\n" +
                    "Cost = " + generationUpgradeCost() + " " + resourceToString(costResourceType());
            }
            else if (resourceType == ResourceType.food)
            {
                return "Buy another Kitchen?\n" +
                    "Cost = " + generationUpgradeCost() + " " + resourceToString(costResourceType());
            }
            else if (resourceType == ResourceType.minerals)
            {
                return "Expand the Mine?\n" +
                    "Cost = " + generationUpgradeCost() + " " + resourceToString(costResourceType());
            }
            return "error";
        }
        else
        {
            return "Upgrade Storage? \n" +
                "Cost = " + generationUpgradeCost() + " " + resourceToString(costResourceType());
        }
    }
    //method for setting the room info text:
    public void setRoomInfo()
    {
        if (resourceType == ResourceType.catpower)
        {
            roomInfoText.GetComponent<TextMeshProUGUI>().SetText("Cardboard Box Fort lvl: " + (timesGenerationUpgraded + 1) + ".\n" +
                "Storage lvl: " + (timesInventUpgraded + 1) + ".");
        }
        else if (resourceType == ResourceType.food)
        {
            roomInfoText.GetComponent<TextMeshProUGUI>().SetText("Kitchen lvl: " + (timesGenerationUpgraded + 1) + ".\n" +
                "Storage lvl: " + (timesInventUpgraded + 1) + ".");
        }
        else if (resourceType == ResourceType.minerals)
        {
            roomInfoText.GetComponent<TextMeshProUGUI>().SetText("Mine lvl: " + (timesGenerationUpgraded + 1) + ".\n" +
                "Storage lvl: " + (timesInventUpgraded + 1) + ".");
        }
        return;
    }

}
