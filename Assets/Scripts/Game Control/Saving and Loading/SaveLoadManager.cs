using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance {
        set;
        get;
    }

    public SaveInfomation infomation;

    public void Awake()
    {
        //this wont be destroyed between scenes
        //DontDestroyOnLoad(gameObject);  

        //loads a save when it is opened
        Instance = this;
        Load();

        InvokeRepeating("AutoSave", 300, 300);
    }

    private void OnApplicationPause(bool pause)
    {
        Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        //saves the data using save helper to turn info into a string that can be put in playerprefs
        infomation.catPower = gameObject.GetComponent<User>().catPower;
        infomation.minerals = gameObject.GetComponent<User>().minerals;
        infomation.food = gameObject.GetComponent<User>().food;

        infomation.discoveredCats = CatList.getInstance().discoveredCats;

        gameObject.GetComponent<BuildRoom>().RefreshRooms();

        infomation.rooms = gameObject.GetComponent<BuildRoom>().rooms;
        infomation.roomCount = gameObject.GetComponent<BuildRoom>().roomCount;
        infomation.nodeLength = gameObject.GetComponent<BuildingNodePlacer>().nodeLength;
        if (infomation.nodeLength > 0) {
            infomation.nodeY = gameObject.GetComponent<BuildingNodePlacer>().node.transform.position.y;
        }
        else {
            infomation.nodeY = -1.6f;
        }
        //cats
        List<CatInfo> catinfoList = new List<CatInfo>();
        foreach (GameObject cat in gameObject.GetComponent<CatBuilder>().catList) {
            catinfoList.Add(new CatInfo(cat));
        }
        infomation.cats = catinfoList;
        //infomation.cats = gameObject.GetComponent<ScreenCatList>().getCatInfo();
        infomation.catCount = gameObject.GetComponent<CatBuilder>().catList.ToArray().Length;

        infomation.unlockedArtifacts = gameObject.GetComponent<ArtifactsFound>().GetUnlockedArtifacts();
        infomation.unlockedArtifactCount = gameObject.GetComponent<ArtifactsFound>().unlockedArtifactsCount;
        ArtifactSaveInfo artifactSaveInfo = new ArtifactSaveInfo();
        infomation.spawnedArtifacts = artifactSaveInfo.makeSaveInfo(gameObject.GetComponent<ArtifactsFound>().spawnedArtifacts, gameObject.GetComponent<ArtifactsFound>().artifactCount, gameObject.GetComponent<ArtifactsFound>().allArtifacts);

        infomation.timeSaved = DateTime.Now;

        infomation.userName = gameObject.GetComponent<User>().username;
        infomation.highScore = gameObject.GetComponent<User>().highScore;

        infomation.firstLoad = gameObject.GetComponent<CatGameFlags>().firstLoad;
        infomation.milestone1 = gameObject.GetComponent<CatGameFlags>().milestone1;
        infomation.milestone2 = gameObject.GetComponent<CatGameFlags>().milestone2;
        infomation.milestone3 = gameObject.GetComponent<CatGameFlags>().milestone3;
        infomation.milestone4 = gameObject.GetComponent<CatGameFlags>().milestone4;
        infomation.milestone5 = gameObject.GetComponent<CatGameFlags>().milestone5;
        infomation.milestone6 = gameObject.GetComponent<CatGameFlags>().milestone6;
        infomation.milestone7 = gameObject.GetComponent<CatGameFlags>().milestone7;
        infomation.milestone8 = gameObject.GetComponent<CatGameFlags>().milestone8;
        infomation.milestone9 = gameObject.GetComponent<CatGameFlags>().milestone9;
        infomation.milestone10 = gameObject.GetComponent<CatGameFlags>().milestone10;
        infomation.milestone11 = gameObject.GetComponent<CatGameFlags>().milestone11;
        infomation.milestone12 = gameObject.GetComponent<CatGameFlags>().milestone12;
        infomation.milestone13 = gameObject.GetComponent<CatGameFlags>().milestone13;

        PlayerPrefs.SetString("Save Info", SaveHelper.Serialise<SaveInfomation>(infomation));
        Debug.Log(SaveHelper.Serialise<SaveInfomation>(infomation));
    }

    public void Load() {
        //loads data from playerprefs and uses the save helper to translate the info back into the save infomation script
        if (PlayerPrefs.HasKey("Save Info")) {
            infomation = SaveHelper.Deserialise<SaveInfomation>(PlayerPrefs.GetString("Save Info"));
            Debug.Log(PlayerPrefs.GetString("Save Info"));

            gameObject.GetComponent<User>().catPower = infomation.catPower;
            gameObject.GetComponent<User>().food = infomation.food;
            gameObject.GetComponent<User>().minerals = infomation.minerals;

            CatList.getInstance().discoveredCats = infomation.discoveredCats;
            gameObject.GetComponent<BuildRoom>().rooms = infomation.rooms;
            gameObject.GetComponent<BuildRoom>().roomCount = infomation.roomCount;

            gameObject.GetComponent<BuildRoom>().LoadRooms();

            gameObject.GetComponent<BuildingNodePlacer>().nodeLength = infomation.nodeLength;
            gameObject.GetComponent<BuildingNodePlacer>().LoadNode(infomation.nodeY);

            foreach (CatInfo catInfo in infomation.cats) {
                gameObject.GetComponent<CatBuilder>().createCat(catInfo);
            }
            foreach (GameObject cat in gameObject.GetComponent<CatBuilder>().catList) {
                foreach (CatListDisplay catListDisplay in gameObject.GetComponent<SceneControl>().catListDisplayList) {
                    if (catListDisplay.catType == cat.GetComponent<Cat>().catType) {
                        catListDisplay.assigned = true;
                    }
                }
            }
            //gameObject.GetComponent<ScreenCatList>().setFromCatInfo(infomation.cats, infomation.catCount);

            gameObject.GetComponent<ArtifactsFound>().SetUnlockedArtifacts(infomation.unlockedArtifacts);
            gameObject.GetComponent<ArtifactsFound>().unlockedArtifactsCount = infomation.unlockedArtifactCount;

            gameObject.GetComponent<ArtifactsFound>().loadSaveInfo(infomation.spawnedArtifacts);

            gameObject.GetComponent<User>().username = infomation.userName;
            gameObject.GetComponent<User>().highScore = infomation.highScore;

            gameObject.GetComponent<CatGameFlags>().firstLoad = infomation.firstLoad;
            gameObject.GetComponent<CatGameFlags>().milestone1 = infomation.milestone1;
            gameObject.GetComponent<CatGameFlags>().milestone2 = infomation.milestone2;
            gameObject.GetComponent<CatGameFlags>().milestone3 = infomation.milestone3;
            gameObject.GetComponent<CatGameFlags>().milestone4 = infomation.milestone4;
            gameObject.GetComponent<CatGameFlags>().milestone5 = infomation.milestone5;
            gameObject.GetComponent<CatGameFlags>().milestone6 = infomation.milestone6;
            gameObject.GetComponent<CatGameFlags>().milestone7 = infomation.milestone7;
            gameObject.GetComponent<CatGameFlags>().milestone8 = infomation.milestone8;
            gameObject.GetComponent<CatGameFlags>().milestone9 = infomation.milestone9;
            gameObject.GetComponent<CatGameFlags>().milestone10 = infomation.milestone10;
            gameObject.GetComponent<CatGameFlags>().milestone11 = infomation.milestone11;
            gameObject.GetComponent<CatGameFlags>().milestone12 = infomation.milestone12;
            gameObject.GetComponent<CatGameFlags>().milestone13 = infomation.milestone13;
        }
        else {//if there is no save infomation makes a new blank save
            infomation = new SaveInfomation();
            Save();
        }

        void AutoSave() {
            Save();
        }
    }

    
}
