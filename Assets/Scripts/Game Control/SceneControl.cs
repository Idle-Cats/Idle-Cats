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

    public CatBuilder catBuilder;

    public int catCount = 0;

    public static CatType catTypeSpawn;

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

        // if cat is less than the number of rooms add cat
        if (catCount < buildRoom.roomCount) {
        // add cat prefab to screen
            // GameObject cat = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            // cat.SetActive(true);
            // cat.GetComponent<Cat>().setCatType(catType);
            catBuilder.createCat(catType);
            print("Cat added");
        // hide cat panel
            hideCatPanel();
        // increment cat count
            catCount++;
        }

        // // hide cat panel
        // hideCatPanel();
        // // add cat prefab to screen
        // GameObject cat = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        // cat.SetActive(true);
    }
}
