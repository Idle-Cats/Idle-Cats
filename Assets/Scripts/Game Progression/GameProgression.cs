using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static User;
using static Cats;
using static CatList;

public class GameProgression : MonoBehaviour
{
    //TO DO: 
    //Add in milestone 10 when upgrade room is finished
    //Add in milestone 11 when revamping cats
    //Add in milestone 13 when upgrade room can upgrade

    public CatGameFlags flags;
    CatList catList;

    public int buttonPressCounter;

    public int crazyCatCounter;

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
    public GameObject milestone13;

    // Start is called before the first frame update
    void Start()
    {
        catList = CatList.getInstance();

        Debug.Log(catList.discoveredCats);

        crazyCatCounter = PlayerPrefs.GetInt("PartyCatCount");

        flags = gameObject.GetComponent<CatGameFlags>();

        if (flags.first_load == 0) {
            ShowWelcome();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Food + Minerals + Coins > 1000 && flags.milestone4 == 0) {
            foodReached1000();
        }

        if (Food + Minerals + Coins > 10000 && flags.milestone5 == 0) {
            foodReached10000();
        }

        if (Food + Minerals + Coins > 100000 && flags.milestone6 == 0) {
            foodReached100000();
        }

        if (Food + Minerals + Coins > 1000000 && flags.milestone7 == 0) {
            foodReached1000000();
        }
    }

    void OnApplicationQuit() {
        PlayerPrefs.SetInt("PartyCatCount", crazyCatCounter);
    }

    public void CloseWelcome() {
        flags.first_load = 1;
        Debug.Log(flags.first_load);
        welcome_panel.SetActive(false);
    }

    void ShowWelcome() {
        welcome_panel.SetActive(true);
    }

    public void CloseMilestone1() {
        milestone1.SetActive(false);
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

    public void CloseMilestone13() {
        milestone13.SetActive(false);
    }

    void ShowMilestone13() {
        milestone13.SetActive(true);
    }

    public void buildRoomCheck() {
        if (flags.milestone1 == 0) {
            flags.milestone1 = 1;
            ShowMilestone1();
            Cats newCat = new Cats(CatType.GREY);
            catList.AddCat(newCat);
        }

        if (flags.milestone12 == 0 && gameObject.GetComponent<BuildRoom>().roomCount > 10) {
            flags.milestone12 = 1;
            ShowMilestone12();
            Cats newCat = new Cats(CatType.PARTY);
            catList.AddCat(newCat);
        }

        if (flags.milestone2 == 0 && gameObject.GetComponent<BuildRoom>().roomCount > 20) {
            flags.milestone2 = 1;
            ShowMilestone2();
            Cats newCat = new Cats(CatType.BROWN);
            catList.AddCat(newCat);
        }
    }

    public void caughtPartyCat() {
        if (flags.milestone3 == 0) {
            flags.milestone3 = 1;
            ShowMilestone3();
            Cats newCat = new Cats(CatType.WHITE);
            catList.AddCat(newCat);
        }

        crazyCatCounter++;

        if (crazyCatCounter >= 50 && flags.milestone9 == 0) {
            flags.milestone9 = 1;
            ShowMilestone9();
            Cats newCat = new Cats(CatType.RED);
            catList.AddCat(newCat);
        }
    }

    void foodReached1000() {
        flags.milestone4 = 1;
        ShowMilestone4();
        Cats newCat = new Cats(CatType.GINGER);
        catList.AddCat(newCat);
    }

    void foodReached10000() {
        flags.milestone5 = 1;
        ShowMilestone5();
        Cats newCat = new Cats(CatType.TEAL);
        catList.AddCat(newCat);
    }

    void foodReached100000() {
        flags.milestone6 = 1;
        ShowMilestone6();
        Cats newCat = new Cats(CatType.PINK);
        catList.AddCat(newCat);
    }

    void foodReached1000000() {
        flags.milestone7 = 1;
        ShowMilestone7();
        Cats newCat = new Cats(CatType.BLUE);
        catList.AddCat(newCat);
    }

    public void buttonPressCount() {
        buttonPressCounter++;

        if (flags.milestone8 == 0 && buttonPressCounter >= 1000) {
            flags.milestone8 = 1;
            ShowMilestone8();
            Cats newCat = new Cats(CatType.GREEN);
            catList.AddCat(newCat);
        }
    }
}
