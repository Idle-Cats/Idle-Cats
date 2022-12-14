using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGameFlags : MonoBehaviour
{
    //flags for first time opening game
    public int firstLoad = 0;

    //flags for milestones
    //TO DO: Rename milestones so they are more descriptive
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

    public int artifactTutorial = 0;

    public bool resourcesCanBeClicked = true;

    void Start() {
        //Load();
    }

    //void OnApplicationQuit() {
    //    Save();
    //}

    //void OnApplicationPause(bool pause)
    //{
    //    Save();
    //}

    void Load() {
        firstLoad = PlayerPrefs.GetInt("CatGameFlags0");
        milestone1 = PlayerPrefs.GetInt("CatGameFlags1");
        milestone2 = PlayerPrefs.GetInt("CatGameFlags2");
        milestone3 = PlayerPrefs.GetInt("CatGameFlags3");
        milestone4 = PlayerPrefs.GetInt("CatGameFlags4");
        milestone5 = PlayerPrefs.GetInt("CatGameFlags5");
        milestone6 = PlayerPrefs.GetInt("CatGameFlags6");
        milestone7 = PlayerPrefs.GetInt("CatGameFlags7");
        milestone8 = PlayerPrefs.GetInt("CatGameFlags8");
        milestone9 = PlayerPrefs.GetInt("CatGameFlags9");
        milestone10 = PlayerPrefs.GetInt("CatGameFlags10");
        milestone11 = PlayerPrefs.GetInt("CatGameFlag11");
        milestone12 = PlayerPrefs.GetInt("CatGameFlags12");
        milestone12 = PlayerPrefs.GetInt("CatGameFlags12");
        artifactTutorial = PlayerPrefs.GetInt("ArtfiactTutorialFlag");
    }

    void Save() {
        PlayerPrefs.SetInt("CatGameFlags0", firstLoad);
        PlayerPrefs.SetInt("CatGameFlags1", milestone1);
        PlayerPrefs.SetInt("CatGameFlags2", milestone2);
        PlayerPrefs.SetInt("CatGameFlags3", milestone3);
        PlayerPrefs.SetInt("CatGameFlags4", milestone4);
        PlayerPrefs.SetInt("CatGameFlags5", milestone5);
        PlayerPrefs.SetInt("CatGameFlags6", milestone6);
        PlayerPrefs.SetInt("CatGameFlags7", milestone7);
        PlayerPrefs.SetInt("CatGameFlags8", milestone8);
        PlayerPrefs.SetInt("CatGameFlags9", milestone9);
        PlayerPrefs.SetInt("CatGameFlags10", milestone10);
        PlayerPrefs.SetInt("CatGameFlag11", milestone11);
        PlayerPrefs.SetInt("CatGameFlags12", milestone12);
        PlayerPrefs.SetInt("ArtfiactTutorialFlag", artifactTutorial);
    }
}
