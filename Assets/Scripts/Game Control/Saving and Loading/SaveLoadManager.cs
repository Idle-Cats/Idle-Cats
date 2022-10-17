using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveLoadManager : MonoBehaviour
{
    public TestAdButton adController;
    public CloudSaveData cloudSave;

    private User user;
    private BuildRoom buildRoom;

    public bool continueSave = false;
    public string data;

    public bool isConnected;
    public bool connectionChecked = false;

    public static SaveLoadManager Instance {
        set;
        get;
    }

    public SaveInfomation infomation;

    public void Awake()
    {
        //loads a save when it is opened
        Instance = this;
        cloudSave.SetSaveLoadManager(this);
        cloudSave.SetGameProgression(gameObject.GetComponent<GameProgression>());
        cloudSave.CheckConnection();
        Load();

        InvokeRepeating("AutoSave", 300, 300);
    }

    private void Update()
    {
        if (connectionChecked) {
            if (isConnected) {
                if (continueSave) {
                    LoadFromData(data);
                    continueSave = false;
                    connectionChecked = false;
                }
            }
            else {
                LoadFromData(PlayerPrefs.GetString("Save Info"));
                connectionChecked = false;
            }
        }
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

        infomation.rooms = gameObject.GetComponent<BuildRoom>().rooms;//RENAME RESEARCHING TO ACTIVE
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
        string username = gameObject.GetComponent<User>().username;
        infomation.userName = username;
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

        infomation.triesSinceLastAd = adController.timeSinceLastAd;

        infomation.crazyCatCounter = gameObject.GetComponent<GameProgression>().crazyCatCounter;

        string data = SaveHelper.Serialise<SaveInfomation>(infomation);

        PlayerPrefs.SetString("Save Info", data);
        Debug.Log(data);
        cloudSave.WriteNewUser(data, username);
    }

    public void Load() {
        user = gameObject.GetComponent<User>();
        buildRoom = gameObject.GetComponent<BuildRoom>();

        //loads data from playerprefs and uses the save helper to translate the info back into the save infomation script
        if (PlayerPrefs.HasKey("Save Info")) {
            infomation = SaveHelper.Deserialise<SaveInfomation>(PlayerPrefs.GetString("Save Info"));
            Debug.Log(PlayerPrefs.GetString("Save Info"));
            string username = infomation.userName;
            cloudSave.LoadUser(username, PlayerPrefs.GetString("Save Info"));
        }
        else {//if there is no save infomation makes a new blank save
            infomation = new SaveInfomation();
            gameObject.GetComponent<WelcomeScreenControl>().CheckWelcome();
        }
    }

    public void LoadFromData(string data) {
        infomation = SaveHelper.Deserialise<SaveInfomation>(data);
        Debug.Log("Cloud Save Data was different" + data);
        FinishLoad();

        gameObject.GetComponent<GameProgression>().CheckWelcome();
    }

    void AutoSave()
    {
        Save();
    }

    private string FinishLoad() {
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

        //materials
        user.catPower = infomation.catPower;
        user.food = infomation.food;
        user.minerals = infomation.minerals;

        CatList.getInstance().discoveredCats = infomation.discoveredCats;
        buildRoom.rooms = infomation.rooms;
        buildRoom.roomCount = infomation.roomCount;

        buildRoom.LoadRooms();

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

        gameObject.GetComponent<ArtifactsFound>().SetUnlockedArtifacts(infomation.unlockedArtifacts);
        gameObject.GetComponent<ArtifactsFound>().unlockedArtifactsCount = infomation.unlockedArtifactCount;

        gameObject.GetComponent<ArtifactsFound>().loadSaveInfo(infomation.spawnedArtifacts);

        string username = infomation.userName;

        gameObject.GetComponent<User>().username = username;
        gameObject.GetComponent<User>().highScore = infomation.highScore;

        adController.timeSinceLastAd = infomation.triesSinceLastAd;

        gameObject.GetComponent<GameProgression>().crazyCatCounter = infomation.crazyCatCounter;

        return username;
    }


}
