using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressionHelper
{
    public CatList catList;

    public int food;
    public int minerals;
    public int catPower;

    public int roomCount;
    
    public int milestone1 = 0;
    public int milestone2 = 0;
    public int milestone3 = 0;
    public int milestone4 = 0;
    public int milestone5 = 0;
    public int milestone6 = 0;
    public int milestone7 = 0;
    public int milestone8 = 0;
    public int milestone9 = 0;
    public int milestone10 = 0;
    public int milestone11 = 0;
    public int milestone12 = 0;

    public void CheckUserResources() {
        if (food + minerals + catPower >= 1000) {
            foodReached1000();
        }

        if (food + minerals + catPower >= 10000) {
            foodReached10000();
        }

        if (food + minerals + catPower >= 100000) {
            foodReached100000();
        }

        if (food + minerals + catPower >= 1000000) {
            foodReached1000000();
        }
    }

    public void buildRoomCheck() {
        if (milestone1 == 0) {
            //add cat from milestone1
            //Debug.Log("milestone1");
           catList.AddCatType(CatType.GREY);
        }

        if (milestone12 == 0 && roomCount > 10) {
            //Debug.Log("Milestone12");
            milestone12 = 1;

            //add cat from milestone12
            catList.AddCatType(CatType.PARTY);
        }

        if (milestone2 == 0 && roomCount > 20) {
            milestone2 = 1;

            //add cat from milestone2
            catList.AddCatType(CatType.BROWN);
        }
    }

    void foodReached1000() {
        catList.AddCatType(CatType.GINGER);
    }

    void foodReached10000() {
        catList.AddCatType(CatType.TEAL);
    }

    void foodReached100000() {
        catList.AddCatType(CatType.PINK);
    }

    void foodReached1000000() {
        catList.AddCatType(CatType.BLUE);
    }
}
