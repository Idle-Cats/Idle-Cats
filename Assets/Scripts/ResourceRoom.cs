using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceRoom : MonoBehaviour
{
    //looks good to me
    //skeleton class for resource rooms
    // Start is called before the first frame update

    public float roomInvent = 0;
    public float upgradeModifier = 0;
    public float roomCapacity = 0;
    public float resourceGen = 0;
    public string name = "ResourceRoom";
    [SerializeField]
    private GameObject resourceCounter;
    public float globalResource = 0; //TODO make this global

    void Start()
    {
        //initialise values here
        //temp placeholder code:
        this.name = "Fishing Room";
        this.roomCapacity = 100;
        this.resourceGen = 1;
        InvokeRepeating("updateRoom", 0.0f, 1.0f);
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
        this.globalResource = resourceRoom.globalResource;
    }

    public ResourceRoomSave MakeCopy() {
        return new ResourceRoomSave(roomInvent, upgradeModifier, roomCapacity, resourceGen, name, globalResource);
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
            globalResource = globalResource + roomInvent;
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
