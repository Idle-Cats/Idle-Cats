using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ArtifactRoom : MonoBehaviour
{
    //nathan is here
    //he says we suck
    //this is a skeleton class for timed rooms

    // need upgrade object with constructor
    //costs, timer, gain.

    private bool researching = false;
    [SerializeField]
    private float timeLength = 0;
    [SerializeField]
    private float percentDone = 0.0f;
    private string roomTitle = null;
    [SerializeField]
    private GameObject slider;

    private float baseTimeReduction = 1;
    private RoomBoost roomBoost;

    [SerializeField]
    private float initialLength;

    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject collectButton;

    [SerializeField]
    private GameObject artifactPrefab;

    // Start is called before the first frame update
    void Start()
    {
        roomBoost = gameObject.GetComponent<RoomBoost>();
        //
    }

    //where do i put this?
    public void applyResearch()
    {
        InvokeRepeating("updateArtifactTimerLength", 0.0f, 1.0f);
    }

    public void clickCollect()
    {
        //Collect artifact here
        Artifact artifact = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<ArtifactsFound>().GetRandomArtifact();
        Debug.Log(artifact);
        if (artifact != null) {
            GameObject newArtifact = Instantiate(artifactPrefab, gameObject.transform.position, Quaternion.identity);
            newArtifact.GetComponent<ArtifactDisplay>().artifact = artifact;
            newArtifact.GetComponent<ArtifactDisplay>().RefreshSelf();
            newArtifact.GetComponent<CurrentRoom>().currentRoom = gameObject;
            gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<ArtifactsFound>().AddArtifact(newArtifact);
        }
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
        initialLength = this.timeLength;
        applyResearch();
    }

    void setTimer(int timeLength, float initialLength)
    {
        this.timeLength = timeLength;
        this.roomTitle = "Digging for artifacts";
        this.researching = true;
        this.initialLength = initialLength;
        applyResearch();
    }

    public void startDig()
    {
        Debug.Log("Dig Started");
        startButton.SetActive(false);
        slider.SetActive(true);
        setTimer(60);
    }

    public void updateArtifactTimerLength()
    {
        if (this.timeLength > 0) {
            this.timeLength -= (baseTimeReduction * (1 + roomBoost.boostAmount));
            this.percentDone = ((float)this.timeLength / (float)initialLength) * 100;

            slider.GetComponent<Slider>().value = percentDone;
        }
        if (this.timeLength <= 0) {
            setTimer();
            collectButton.SetActive(true);

            CancelInvoke("updateArtifactTimerLength");
        }
    }

    public void calculateOfflineProgress()
    {
        if (researching) {
            DateTime dateQuit = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<SaveLoadManager>().infomation.timeSaved;
            DateTime dateNow = DateTime.Now;

            if (dateNow > dateQuit) {
                TimeSpan timeSpan = dateNow - dateQuit;
                timeLength -= (float)(this.baseTimeReduction * timeSpan.TotalSeconds);
            }
            slider.SetActive(true);
            startButton.SetActive(false);
            if (timeLength <= 0) {
                setTimer();
                collectButton.SetActive(true);
            }
            else {
                setTimer((int)Math.Ceiling(timeLength), initialLength);
            }

            this.percentDone = ((float)this.timeLength / (float)initialLength) * 100;

            slider.GetComponent<Slider>().value = percentDone;
        }
    }

    public TimerRoomSave MakeCopy() {
        TimerRoomSave timerRoomSave = new TimerRoomSave(timeLength, initialLength, researching);

        return timerRoomSave;
    }

    public void GetCopy(TimerRoomSave timerRoomSave) {
        timeLength = timerRoomSave.timeLength;
        initialLength = timerRoomSave.initialLength;
        researching = timerRoomSave.researching;
    }
}
