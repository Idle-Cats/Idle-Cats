using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
using UnityEngine.UI;
using static BuildRoom;

public class SceneControl : MonoBehaviour
{
    public GameObject CatPanel;
    public GameObject OpenCatList;

    public GameObject referenceCat;

    public CatBuilder catBuilder;

    public int catCount = 0;

    public static CatType catTypeSpawn;

    public GameObject AddCatButton;

    //show main game
    public void GameScene() {  
        SceneManager.LoadScene("AlexLScene");
    }

    // Show welcome screen
    public void WelcomeScene() {  
        SceneManager.LoadScene("WelcomeScreen");
    }

    public void showCatPanel() 
    {
        OpenCatList.SetActive(false);
        CatPanel.SetActive(true);
    }

    public void hideCatPanel() 
    {
        OpenCatList.SetActive(true);
        CatPanel.SetActive(false);
    }

    public void addCat() {
        CatType catType = catTypeSpawn;
        BuildRoom buildRoom = GetComponent<BuildRoom>();

        AddCatButton.SetActive(false);

        // if cat is less than the number of rooms add cat
        if (catCount < buildRoom.roomCount) {
            catBuilder.createCat(catType);

            referenceCat.GetComponent<CatListDisplay>().assigned = true;
        //catType assigned = true;
            print("Cat added");
        // hide cat panel
            hideCatPanel();
        // increment cat count
            catCount++;
        }
    }

    public void SetActiveCat(GameObject cat){
        referenceCat = cat;
    }
}
