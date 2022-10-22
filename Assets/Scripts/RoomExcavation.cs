using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RoomExcavation : MonoBehaviour
{
    //this is the template for timerRoom
    //Goal here is to turn this into a room placeholder for any current excavating room.
    
        //Start: Empty room, option to start excavating
        //formula for cost of this:
        // roomDepth ^ roomDepth
        //todo: implement a global variable named roomDepth set to 0, increment it by one each time this script is finished
        //start timer
        //formula for length is roomDepth * 30s (placeholder)
        //when timer finished, tap to stop construction
        //removes placeholder room, replaces with empty room
        //creates new copy of this room below empty room
        //increment roomDepth++

        //todo fix global variables roomDepth, resourcecosts, 




    public bool researching = false;
    private bool awaitingCollect = false;
    [SerializeField]
    public int timeLength = 0;
    [SerializeField]
    private float percentDone = 0.0f;
    public string researchTitle = null;
    [SerializeField]
    private GameObject slider;
    [SerializeField]
    public int initialLength;
    [SerializeField]
    private GameObject research;

    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject collectButton;
    [SerializeField]
    private GameObject emptyRoom;

    private float roomHeight;

    //replace this with a reference to global variable
    private int roomDepth = 0;

    // Start is called before the first frame update
    public void Start()
    {
        //
        roomDepth = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().roomDepth;
        roomHeight = gameObject.GetComponent<SpriteRenderer>().size.y;
        research.GetComponent<TextMeshProUGUI>().SetText("Excavate New Room?\n Cost:" + (roomDepth * roomDepth) + " Cat Power.");
        collectButton.SetActive(false);
    }

    //TODO put a method here that checks for pricing  for startButton


//A boolean method for checking if player has enough resources to dig a new room
    bool canAfford()    
    {
        int currentResources = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().catPower;
        int currentCost = (roomDepth * roomDepth);

        if (currentResources >= currentCost)
        {
            return true;
        }
        return false;
    }
   
    //this is a method that does the timer
     public void applyResearch(int timerLength)
    {
        initialLength = timerLength;
        InvokeRepeating("updateTimerLength", 0.0f, 1.0f);
    }

    public void applyResearch(int timerLength, int initialLength)
    {
        this.initialLength = initialLength;
        InvokeRepeating("updateTimerLength", 0.0f, 1.0f);
    }

    //this is the method that executes when clicking the collect button
    public void clickCollect()
    {
        setTimer();
        //make button unclickable

        //apply results of collecting timer here
        //putting an empty room on top of this
        GameObject diggyDiggyHole = Instantiate(emptyRoom, gameObject.transform.position, Quaternion.identity);
        //putting current room down
        gameObject.transform.position = new Vector2(0, -1.6f - (roomHeight * 1.5f * (roomDepth+1)));

        //so put in empty room, put in new this room below it, increment roomDepth
        roomDepth++; //TODO make this global
        gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().roomDepth = roomDepth;
        research.GetComponent<TextMeshProUGUI>().SetText("Excavate New Room?\n Cost:" + (roomDepth * roomDepth) + " Cat Power.");
        RoomInformation roomInfo = gameObject.GetComponent<RoomInformation>();
        BuildRoom buildRoom = roomInfo.gameControl.GetComponent<BuildRoom>();
        buildRoom.emptyRooms.Enqueue(diggyDiggyHole);
        awaitingCollect = false;
    }

    // Update is called once per frame
    void Update()
    {
        roomDepth = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().roomDepth;
        //call canAfford, have it make start digging buton available ONLY if not already digging
        if ((canAfford() == true) && (researching == false) && (awaitingCollect == false)) {
            //make start button active
            startButton.SetActive(true);
        }
        else {
            startButton.SetActive(false);
        }
        
        
    }
    //room timer stuff

        //method for timer not running
    void setTimer()
    {
        this.researching = false;
        collectButton.SetActive(false);
        slider.SetActive(false);
        this.researchTitle = "Room not busy";
    }

    //method for timer running
    void setTimer(int timeLength, string researchTitle)
    {
        slider.SetActive(true);
        startButton.SetActive(false);
        this.timeLength = timeLength;
        this.researchTitle = researchTitle;
        this.researching = true;
        applyResearch(timeLength);
    }

    public void setTimer(int timeLength, string researchTitle, int initialLength) {
        slider.SetActive(true);
        startButton.SetActive(false);
        this.timeLength = timeLength;
        this.researchTitle = researchTitle;
        this.researching = true;
        applyResearch(timeLength, initialLength);
    }

    //method for when start button is clicked
    //basically only contains the increasing time formula, and removes resource cost
    public void startExcavation()
    {
        int cost = (roomDepth * roomDepth);
        gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().catPower -= cost;
        research.GetComponent<TextMeshProUGUI>().SetText("Excavating! Your cats are hard at work.");
        setTimer(((roomDepth + 1) * 30), "Excavation in progress");
    }

    //method that runs the timer
    public void updateTimerLength()
    {
        if (this.timeLength > 0)
        {
            this.timeLength--;
            this.percentDone = ((float)this.timeLength / (float)initialLength) * 100;
            research.GetComponent<TextMeshProUGUI>().SetText(researchTitle);

            slider.GetComponent<Slider>().value = percentDone;
        }
        if (this.timeLength <= 0)
        {
            setTimer();
            collectButton.SetActive(true);
            research.GetComponent<TextMeshProUGUI>().SetText("Excavation Finished!");
            awaitingCollect = true;
            CancelInvoke("updateTimerLength");
        }
    }
    //tap room brings up UI where select between three choices.

    public void calculateOfflineProgress(int timeLength, string researchTitle, int initialLength, bool researching)
    {
        this.timeLength = timeLength;
        this.researchTitle = researchTitle;
        this.initialLength = initialLength;
        this.researching = researching;

        if (researching) {
            DateTime dateQuit = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<SaveLoadManager>().infomation.timeSaved;
            DateTime dateNow = DateTime.Now;

            if (dateNow > dateQuit) {
                TimeSpan timeSpan = dateNow - dateQuit;
                timeLength -= (int)(this.initialLength * timeSpan.TotalSeconds);
            }
            slider.SetActive(true);
            startButton.SetActive(false);
            if (timeLength <= 0) {
                setTimer();
                collectButton.SetActive(true);
            }
            else {
                setTimer((timeLength), researchTitle, initialLength);
            }

            this.percentDone = ((float)this.timeLength / (float)initialLength) * 100;

            slider.GetComponent<Slider>().value = percentDone;
        }
    }
}
