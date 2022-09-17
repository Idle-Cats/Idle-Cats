using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArtifactRoom : MonoBehaviour
{
    //nathan is here
    //he says we suck
    //this is a skeleton class for timed rooms

        // need upgrade object with constructor
        //costs, timer, gain.

    private bool researching = false;
    [SerializeField]
    private int timeLength = 0;
    [SerializeField]
    private float percentDone = 0.0f;
    private string roomTitle = null;
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
    public void applyResearch()
    {
        initialLength = this.timeLength;

        InvokeRepeating("updateArtifactTimerLength", 0.0f, 1.0f);
    }

    public void clickCollect()
    {
        //Collect artifact here
        collectButton.SetActive(false);
        startButton.SetActive(true);
        slider.SetActive(false);
        this.roomTitle = "Room not busy";
    }

    // Update is called once per frame
    void Update()
    {
    }
    //room timer stuff

    void setTimer()
    {
        this.researching = false;
        this.roomTitle = "Ready to collect";
    }

    void setTimer(int timeLength)
    {
        this.timeLength = timeLength;
        this.roomTitle = "Digging for artifacts";
        this.researching = true;
        applyResearch();
    }

    public void startDig()
    {
        Debug.Log("Dig Started");
        startButton.SetActive(false);
        slider.SetActive(true);
        setTimer(30);
    }

    public void updateArtifactTimerLength()
    {
        if (this.timeLength > 0)
        {
            this.timeLength--;
            this.percentDone = ((float)this.timeLength / (float)initialLength) * 100;

            slider.GetComponent<Slider>().value = percentDone;
        }
        if (this.timeLength <= 0) {
            setTimer();
            collectButton.SetActive(true);

            CancelInvoke("updateArtifactTimerLength");
        }
    }
}
