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
        collectButton.SetActive(false);
        startButton.SetActive(true);
        slider.SetActive(false);
        this.roomTitle = "Room not busy";
        
        int food = genFood();
        int mine = genMinerals();
        int power = genPower();

        Debug.Log("Food: " + food + " Minerals: " + mine + " Power: " + power);

        // add the food, minerals, and power to the user
        gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().catPower += power;
        gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().minerals += mine;
        gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().food += food;
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

        // check if room contains a cat
        if (gameObject.GetComponent<RoomInformation>().containsCat) {
            Debug.Log("Steal Starting");
            startButton.SetActive(false);
            slider.SetActive(true);
            setTimer(10);
            
        } else {
            // make a pop up error message
            Debug.Log("No cat in room");
            return;
        }
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

    public int genMinerals() {
        int currentMinerals = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().minerals;
        // generate a number between 20% and 30% of the current minerals
        int random = UnityEngine.Random.Range(20, 30);
        int minerals = (int)((double)currentMinerals * ((double)random / 100));
        return minerals;
    }

    public int genPower() {
        int currentPower = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().catPower;
        // generate a number between 20% and 30% of the current power
        int random = UnityEngine.Random.Range(20, 30);
        int catPower = (int)((double)currentPower * ((double)random / 100));
        return catPower;
    }

    public int genFood() {
        int currentFood = gameObject.GetComponent<RoomInformation>().gameControl.GetComponent<User>().food;
        // generate a number between 20% and 30% of the current food
        int random = UnityEngine.Random.Range(20, 30);
        int food = (int)((double)currentFood * ((double)random / 100.0d));
        return food;
    }
}
