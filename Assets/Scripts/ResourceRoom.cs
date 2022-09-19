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

    public float roomInvent = 0;
    public RoomBoost roomBoost;
    //public float upgradeModifier = 0;
    public float roomCapacity = 0;
    public float resourceGen = 0;
    public new string name = "ResourceRoom";
    [SerializeField]
    private GameObject resourceCounter;

    public ResourceType resourceType;

    void Start()
    {
        //initialise values here
        //temp placeholder code:
        this.name = "Fishing Room";
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

    void OnApplicationPause() {
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
        //this.upgradeModifier = resourceRoom.upgradeModifier;
        this.roomCapacity = resourceRoom.roomCapacity;
        this.resourceGen = resourceRoom.resourceGen;
        this.name = resourceRoom.name;
        this.roomBoost.boostAmount = resourceRoom.roomBoost;
        this.resourceType = resourceRoom.resourceType;
    }

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

    public void collectResources()
    {
        int roomInventRounded = (int)Math.Floor(roomInvent);
        if (resourceType == ResourceType.catpower) {
            gameObject.GetComponent<RoomInfomation>().gameControl.GetComponent<User>().catPower += roomInventRounded;

        }
        else if (resourceType == ResourceType.minerals) {
            gameObject.GetComponent<RoomInfomation>().gameControl.GetComponent<User>().minerals += roomInventRounded;
        }
        else if (resourceType == ResourceType.food) {
            gameObject.GetComponent<RoomInfomation>().gameControl.GetComponent<User>().food += roomInventRounded;
        }

        roomInvent = roomInvent - roomInventRounded;

        resourceCounter.GetComponent<TextMeshProUGUI>().SetText("Current Resources: " + roomInvent + "/" + roomCapacity);
    }

    public void updateRoom()
    {
        if (roomInvent < roomCapacity)
        {
            addInvent(resourceGen * (1 + roomBoost.boostAmount));
        }

        resourceCounter.GetComponent<TextMeshProUGUI>().SetText("Current Resources: " + roomInvent + "/" + roomCapacity);
    }

    public enum ResourceType {
        minerals,
        catpower,
        food
    }
}
