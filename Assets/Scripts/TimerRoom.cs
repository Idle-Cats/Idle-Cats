using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerRoom : MonoBehaviour
{
    private bool researching = false;
    [SerializeField]
    private int timeLength = 0;
    [SerializeField]
    private float percentDone = 0.0f;
    private int rewardAmount = 0;
    private int rewardType = 0;
    private string researchTitle = null;
    [SerializeField]
    private GameObject slider;
    [SerializeField]
    private int initialLength;

    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject collectButton;

    // Start is called before the first frame update
    void Start()
    {
       //
    }

    //where do i put this?
     public void applyResearch(int timerLength)
    {
        initialLength = timerLength;

        InvokeRepeating("updateArtifactTimerLength", 0.0f, 1.0f);
    }

    //set collect button to clickable


    

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
        collectButton.SetActive(false);
        startButton.SetActive(true);
        slider.SetActive(false);
        this.researchTitle = "Room not busy";
    }

    void setTimer(int timeLength, int rewardAmount, int rewardType, string researchTitle)
    {
        this.rewardAmount = rewardAmount;
        this.rewardType = rewardType;
        this.timeLength = timeLength;
        this.researchTitle = researchTitle;
        this.researching = true;
        applyResearch(timeLength);
    }

    public void startPlaceholder()
    {
        setTimer(300, 1000, 3, "Converting 1000 Catpower");
        startButton.SetActive(false);
        slider.SetActive(true);
        this.rewardType = 3;
        this.rewardAmount = 1000;
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
