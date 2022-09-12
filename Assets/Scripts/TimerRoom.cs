using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerRoom : MonoBehaviour
{
    //nathan is here
    //he says we suck
    //this is a skeleton class for timed rooms

        // need upgrade object with constructor
        //costs, timer, gain.

    private bool researching = false;
    private int timeLength = 0;
    private float percentDone = 0.0f;
    private int rewardAmount = 0;
    private int rewardType = 0;
    private string researchTitle = null;
    [SerializeField]
    private GameObject slider;
   
    // Start is called before the first frame update
    void Start()
    {
       //
    }

    //where do i put this?
    public void applyResearch()
    {
        if (researching)
        {
            int initialLength = this.timeLength;
            while (this.timeLength < 0)
            {
                InvokeRepeating("updateTimerLength", 0.0f, 1.0f);
                //do i need to keep updating percentdone?
                this.percentDone = (this.timeLength / initialLength) * 100;
                
               slider.GetComponent<Slider>().value = percentDone;

            }

            //set collect button to clickable

        }
    }

    public void clickCollect()
    {
        setTimer();
        //make button unclickable
        switch(this.rewardType)
        {
            case 1:
                return;
            case 2:
                return;
            case 3:
                //player invent world resource increase by this.rewardAmount             
                return;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    //room timer stuff

    void setTimer()
    {
        this.researching = false;
        this.researchTitle = "Room not busy";
    }

    void setTimer(int timeLength, int rewardAmount, int rewardType, string researchTitle)
    {
        this.rewardAmount = rewardAmount;
        this.rewardType = rewardType;
        this.timeLength = timeLength;
        this.researchTitle = researchTitle;
        this.researching = true;
    }

    public void startPlaceholder()
    {
        setTimer(300, 1000, 3, "Converting 1000 Catpower");
    }

    public void updateTimerLength()
    {
        if (this.timeLength > 0)
        {
            this.timeLength--;
        }
    }
    //tap room brings up UI where select between three choices.
}
