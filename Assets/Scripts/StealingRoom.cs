using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StealingRoom : MonoBehaviour {
//i hope this code works - i stole from timer rooms

    private bool stealing = false;
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

    // Start is called before the first frame update
    void Start() {
        roomBoost = gameObject.GetComponent<RoomBoost>();
    }

    public void applySteal() {
        InvokeRepeating("updateStealTimerLength", 0.0f, 1.0f);
    }

    public void clickCollect() {
        //Collect artifact here
        Debug.Log("Click collect");
        collectButton.SetActive(false);
        startButton.SetActive(true);
        slider.SetActive(false);
        this.roomTitle = "Room not busy";
        // somehow figure out how much resources to give people @michael help pls!!
    }

    // Update is called once per frame
    void Update() {
        
    }

    void setTimer() {
     this.stealing = false;
     this.roomTitle = "Ready to collect";   
    }

    void setTimer (int timeLength) {
        this.timeLength = timeLength;
        this.roomTitle = "Stealing Resources";
        this.stealing = true;
        initialLength = this.timeLength;
        applySteal();
    }

    void setTimer(int timeLength, float initialLength) {
        this.timeLength = timeLength;
        this.roomTitle = "Digging for artifacts";
        this.stealing = true;
        this.initialLength = initialLength;
        applySteal();
    }

    public void startSteal() {
        Debug.Log("Steal Starting");
        startButton.SetActive(false);
        slider.SetActive(true);
        setTimer(10);
    }

    public void updateStealTimerLength() {
        if (this.timeLength > 0) {
            this.timeLength -= (baseTimeReduction * (1 + roomBoost.boostAmount));
            this.percentDone = ((float)this.timeLength / (float)initialLength) * 100;

            slider.GetComponent<Slider>().value = percentDone;
        }
        if (this.timeLength <= 0) {
            setTimer();
            collectButton.SetActive(true);

            CancelInvoke("updateStealTimerLength");
        }
    }

    public void calculateOfflineProgress() {
        if (stealing) {
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
        TimerRoomSave timerRoomSave = new TimerRoomSave(timeLength, initialLength, stealing);

        return timerRoomSave;
    }

    public void GetCopy(TimerRoomSave timerRoomSave) {
        timeLength = timerRoomSave.timeLength;
        initialLength = timerRoomSave.initialLength;
        stealing = timerRoomSave.researching;
    }
}
