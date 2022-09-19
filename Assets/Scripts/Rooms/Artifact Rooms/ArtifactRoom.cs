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
        initialLength = this.timeLength;

        InvokeRepeating("updateArtifactTimerLength", 0.0f, 1.0f);
    }

    public void clickCollect()
    {
        //Collect artifact here
        Artifact artifact = gameObject.GetComponent<RoomInfomation>().gameControl.GetComponent<ArtifactsFound>().GetRandomArtifact();
        Debug.Log(artifact);
        if (artifact != null) {
            GameObject newArtifact = Instantiate(artifactPrefab, gameObject.transform.position, Quaternion.identity);
            newArtifact.GetComponent<ArtifactDisplay>().artifact = artifact;
            newArtifact.GetComponent<ArtifactDisplay>().RefreshSelf();
            newArtifact.GetComponent<CurrentRoom>().currentRoom = gameObject;
            gameObject.GetComponent<RoomInfomation>().gameControl.GetComponent<ArtifactsFound>().AddArtifact(newArtifact);
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
        applyResearch();
    }

    public void startDig()
    {
        Debug.Log("Dig Started");
        startButton.SetActive(false);
        slider.SetActive(true);
        setTimer(10);
    }

    public void updateArtifactTimerLength()
    {
        if (this.timeLength > 0)
        {
            this.timeLength-= (baseTimeReduction * (1 + roomBoost.boostAmount));
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
