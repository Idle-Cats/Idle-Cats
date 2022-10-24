using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static User;
using static Cat;
using static CatList;

public class GameProgression : MonoBehaviour{
    //holds an instance of the flags script to edit milestone values
    public CatGameFlags flags;
    //catlist object to enable creation of cats when milestones are hit
    public CatList catList;

    //if this gets to 5000 in the current session 
    //milestone is reached
    public int buttonPressCounter;

    //if this gets to 50 in the current session 
    //milestone is reached
    public int crazyCatCounter;

    //user object to check the users values
    private User user;

    //game panels which can be set to active to display a message
    public GameObject welcome_panel;
    public GameObject milestone1;
    public GameObject milestone2;
    public GameObject milestone3;
    public GameObject milestone4;
    public GameObject milestone5;
    public GameObject milestone6;
    public GameObject milestone7;
    public GameObject milestone8;
    public GameObject milestone9;
    public GameObject milestone10;
    public GameObject milestone11;
    public GameObject milestone12;

    //tutorial panels which usually show the user a new feature they need to know about
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial2_1;
    public GameObject milestone1_3;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public GameObject tutorial5;

    //instance of the add room button to set it to unclickable
    public GameObject addRoomButton;

    public bool isInTutorial = false;

    public bool cloudCheckWelcome = false;
    public int food;
    public int minerals;
    public int catPower;

    // Start is called before the first frame update
    void Start()
    {
        //initialises the original values
        user = gameObject.GetComponent<User>();
        catList = CatList.getInstance();

        flags = gameObject.GetComponent<CatGameFlags>();
    }

    public void CheckWelcome() {//allows delay of showing welcome screen so can load in time
        user = gameObject.GetComponent<User>();
        catList = CatList.getInstance();
        flags = gameObject.GetComponent<CatGameFlags>();

        //shows the welcome screen if it is the users first load
        if (flags.firstLoad == 0) {
            ShowWelcome();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cloudCheckWelcome) {
            CheckWelcome();
            cloudCheckWelcome = false;
        }
        //checks if specific resource goals have been hit for the first time and runs
        //their asscoiated function
        food = user.food;
        minerals = user.minerals;
        catPower = user.catPower;

        CheckUserResources();
    }

    public void CheckUserResources() {
        if (food + minerals + catPower >= 1000 && flags.milestone4 == 0) {
            foodReached1000();
        }

        if (food + minerals + catPower >= 10000 && flags.milestone5 == 0) {
            foodReached10000();
        }

        if (food + minerals + catPower >= 100000 && flags.milestone6 == 0) {
            foodReached100000();
        }

        if (food + minerals + catPower >= 1000000 && flags.milestone7 == 0) {
            foodReached1000000();
        }

        if (minerals >= 5000 && flags.artifactTutorial == 0 && gameObject.GetComponent<BuildRoom>().EmptyRoomAvailable()) {
            mineralsReached5000();
        }
    }
    
    public void CloseWelcome() {
        if (flags.firstLoad == 0) {
            welcome_panel.SetActive(false);
            tutorial1.SetActive(true);
        }

    //All functions facilitate the closing and opening of panels
    //after the last panel is closed the associated flag is set to a non 0 number
    }

    void ShowWelcome() {
        if (flags.firstLoad == 0)
            welcome_panel.SetActive(true);
    }

    public void CloseMilestone1() {
        milestone1.SetActive(false);
        addRoomButton.GetComponent<Button>().interactable = false;
        tutorial2.SetActive(true);
    }

    public void CloseTutorial1()
    {
        tutorial1.SetActive(false);
        flags.firstLoad = 1;
    }

    public void CloseTutorial2()
    {
        if (flags.milestone1 == 0) {
            tutorial2.SetActive(false);
            tutorial2_1.SetActive(true);
        }
    }

    public void CloseTutorial2_1()
    {
        if (flags.milestone1 == 0) {
            tutorial2_1.SetActive(false);
            milestone1_3.SetActive(true);   
        }
    }

    public void CloseMilestone1_3() {
        milestone1_3.SetActive(false);
        flags.milestone1 = 1;
        addRoomButton.GetComponent<Button>().interactable = true;
        if (flags.milestone11 == 0) {
            flags.milestone11 = 1;
            ShowMilestone11();
            catList.AddCatType(CatType.WELCOME);
        }
    }

    void ShowTutorial3() {
        tutorial3.SetActive(true);
    }

    public void CloseTutorial3 () {
        if (flags.artifactTutorial == 0 && isInTutorial) {
            tutorial3.SetActive(false);
            tutorial4.SetActive(true);
            addRoomButton.GetComponent<Button>().interactable = false;
            flags.resourcesCanBeClicked = false;
        }
    }

    public void CloseTutorial4() {
        if (flags.artifactTutorial == 0 && isInTutorial) {
            tutorial4.SetActive(false);
            tutorial5.SetActive(true);
            addRoomButton.GetComponent<Button>().interactable = true;
            //Debug.Log("can be clicked");
            flags.resourcesCanBeClicked = true;
        }
    }

    public void CloseTutorial5() {
        flags.artifactTutorial = 1;
        tutorial5.SetActive(false);
        isInTutorial = false;
    }

    void ShowMilestone1() {
        milestone1.SetActive(true);
    }

    public void CloseMilestone2() {
        milestone2.SetActive(false);
    }

    void ShowMilestone2() {
        milestone2.SetActive(true);
    }

    public void CloseMilestone3() {
        milestone3.SetActive(false);
    }

    void ShowMilestone3() {
        milestone3.SetActive(true);
    }

    void ShowMilestone1_3() {
        milestone1_3.SetActive(true);
    }

    public void CloseMilestone4() {
        milestone4.SetActive(false);
    }

    void ShowMilestone4() {
        milestone4.SetActive(true);
    }

    public void CloseMilestone5() {
        milestone5.SetActive(false);
    }

    void ShowMilestone5() {
        milestone5.SetActive(true);
    }

    public void CloseMilestone6() {
        milestone6.SetActive(false);
    }

    void ShowMilestone6() {
        milestone6.SetActive(true);
    }

    public void CloseMilestone7() {
        milestone7.SetActive(false);
    }

    void ShowMilestone7() {
        milestone7.SetActive(true);
    }

    public void CloseMilestone8() {
        milestone8.SetActive(false);
    }

    void ShowMilestone8() {
        milestone8.SetActive(true);
    }

    public void CloseMilestone9() {
        milestone9.SetActive(false);
    }

    void ShowMilestone9() {
        milestone9.SetActive(true);
    }

    public void CloseMilestone10() {
        milestone10.SetActive(false);
    }

    void ShowMilestone10() {
        milestone10.SetActive(true);
    }

    public void CloseMilestone11() {
        milestone11.SetActive(false);
    }

    void ShowMilestone11() {
        milestone11.SetActive(true);
    }

    public void CloseMilestone12() {
        milestone12.SetActive(false);
    }

    void ShowMilestone12() {
        milestone12.SetActive(true);
    }

    //this function runs every time a room is added
    //it checks if the room was the first room
    //the number of rooms is bigger than 10
    //and the number of rooms is bigger than 20 
    //and runs the associated tutorial/milestone if they are
    public void buildRoomCheck() {
        if (flags.milestone1 == 0) {
            ShowMilestone1();
            
            //add cat from milestone1
           catList.AddCatType(CatType.GREY);
        }

        if (flags.milestone12 == 0 && gameObject.GetComponent<BuildRoom>().roomCount > 10) {
            flags.milestone12 = 1;
            ShowMilestone12();

            //add cat from milestone12
            catList.AddCatType(CatType.PARTY);
        }

        if (flags.milestone2 == 0 && gameObject.GetComponent<BuildRoom>().roomCount > 20) {
            flags.milestone2 = 1;
            ShowMilestone2();

            //add cat from milestone2
            catList.AddCatType(CatType.BROWN);
        }
    }

    //this function runs every time the user catches the party cat
    //it checks if it is the first time the cat has been caught
    //and if the cat has been caught 50 times in one session
    public void caughtPartyCat() {
        if (flags.milestone3 == 0) {
            flags.milestone3 = 1;
            ShowMilestone3();
            catList.AddCatType(CatType.WHITE);
        }

        crazyCatCounter++;

        if (crazyCatCounter >= 50 && flags.milestone9 == 0) {
            flags.milestone9 = 1;
            ShowMilestone9();
            catList.AddCatType(CatType.RED);
        }
    }

    //helper functions to control milestone setting when specific resource goals are meet
    void foodReached1000() {
        flags.milestone4 = 1;
        ShowMilestone4();
        catList.AddCatType(CatType.GINGER);
        //Debug.Log("Added cat 64");
    }

    void mineralsReached5000() {
        if (flags.artifactTutorial == 0 && !isInTutorial) {
            isInTutorial = true;
            ShowTutorial3();
        }  
    }

    void foodReached10000() {
        flags.milestone5 = 1;
        ShowMilestone5();
        catList.AddCatType(CatType.TEAL);
        //Debug.Log("Added cat 5");
    }

    void foodReached100000() {
        flags.milestone6 = 1;
        ShowMilestone6();
        catList.AddCatType(CatType.PINK);
        //Debug.Log("Added cat 6");
    }

    void foodReached1000000() {
        flags.milestone7 = 1;
        ShowMilestone7();
        catList.AddCatType(CatType.BLUE);
        //Debug.Log("Added cat 7");
    }

    //counts the number of button presses the user has done this session
    //if the number is bigger than the goal it shows the milestone
    public void buttonPressCount() {
        buttonPressCounter++;

        if (flags.milestone8 == 0 && buttonPressCounter >= 1000) {
            flags.milestone8 = 1;
            ShowMilestone8();
            catList.AddCatType(CatType.GREEN);
        }
    }
}
