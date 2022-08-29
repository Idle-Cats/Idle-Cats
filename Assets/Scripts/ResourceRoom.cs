wusing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRoom : MonoBehaviour
{
    //looks good to me
    //skeleton class for resource rooms
    // Start is called before the first frame update

    private float roomInvent = 0;
    private double upgradeModifier = 0;
    private int roomCapacity = 0;
    private double resourceGen = 0;
    private string name = "ResourceRoom";

    void Start()
    {
        //initialise values here
        //temp placeholder code:
        this.name = "Fishing Room";
        this.roomCapacity = 100;
        this.resourceGen = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //adds a tick of resource gen to roomInvent
        if (roomInvent < roomCapacity)
        {
            addInvent(resourceGen * (1 + upgradeModifier));
        }

        //code for input?
        //if (Input.ClickHere == true)
        //{
        //    globalResource = globalResource + roomInvent;
        //    roomInvent = 0;
        //}
        
    }

    //method for adding to invent making sure capacity isn't exceeded
    void addInvent(int x)
    {
        int tempInvent = roomInvent + x;
        if (tempInvent >= roomCapacity)
        {
            roomInvent = roomCapacity;
        }
        else
        {
            roomInvent = tempInvent;
        }
    }
}
