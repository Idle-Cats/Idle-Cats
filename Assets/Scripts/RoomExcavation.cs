using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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




    private bool researching = false;
    [SerializeField]
    private int timeLength = 0;
    [SerializeField]
    private float percentDone = 0.0f;
    private string researchTitle = null;
    [SerializeField]
    private GameObject slider;
    [SerializeField]
    private int initialLength;

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
    void Start()
    {
        //
        roomHeight = gameObject.GetComponent<SpriteRenderer>().size.y;
    }

    //TODO put a method here that checks for pricing  for startButton



    bool canAfford()    
    {
        int currentResources = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().minerals;
        int currentCost = (roomDepth * roomDepth);

        if (currentResources >= currentCost)
        {
            return true;
        }
        return false;
    }



    //TODO put a title here for displaying current cost?

    //where do i put this?
     public void applyResearch(int timerLength)
    {
        initialLength = timerLength;

        InvokeRepeating("updateArtifactTimerLength", 0.0f, 1.0f);
    }

    //set collect button to clickable

        //todo set visible on buttons as well as disable
    

    public void clickCollect()
    {
        setTimer();
        //make button unclickable

        //apply results of collecting timer here
        //putting an empty room on top of this
        GameObject diggyDiggyHole = Instantiate(emptyRoom, gameObject.transform.position, Quaternion.identity);
        //putting current room down
        gameObject.transform.position = new Vector2(0, -1.6f - (roomHeight * 1.5f * roomDepth));

        //so put in empty room, put in new this room below it, increment roomDepth
        roomDepth++;
    }

    // Update is called once per frame
    void Update()
    {
    }
    //room timer stuff

    void setTimer()
    {
        this.researching = false;
        collectButton.SetActive(false);
        startButton.SetActive(true);
        slider.SetActive(false);
        this.researchTitle = "Room not busy";
    }

    void setTimer(int timeLength, string researchTitle)
    {
        this.timeLength = timeLength;
        this.researchTitle = researchTitle;
        this.researching = true;
        applyResearch(timeLength);
    }

    public void startExcavation()
    {
        setTimer(((roomDepth+1) *30), "Excavation in progress");
        startButton.SetActive(false);
        slider.SetActive(true);
    }

    public void updateTimerLength()
    {
        if (this.timeLength > 0)
        {
            this.timeLength--;
            this.percentDone = ((float)this.timeLength / (float)initialLength) * 100;

            slider.GetComponent<Slider>().value = percentDone;
        }
        if (this.timeLength <= 0)
        {
            setTimer();
            collectButton.SetActive(true);

            CancelInvoke("updateArtifactTimerLength");
        }
    }
    //tap room brings up UI where select between three choices.
}
