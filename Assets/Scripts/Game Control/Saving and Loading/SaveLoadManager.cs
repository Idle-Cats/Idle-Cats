using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    public TestAdButton adController;
    public CloudSaveData cloudSave;

    private User user;
    private BuildRoom buildRoom;

    public bool continueSave = false;
    public string data;
    private string localData;

    public bool isConnected;
    public bool connectionChecked = false;

    private int lastSavedInternet;

    [SerializeField]
    private GameObject loadSavePanel;

    public bool continueLoadUser;

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

        lastSavedInternet = PlayerPrefs.GetInt("Last Saved Via Internet", 1);

        Load();

        InvokeRepeating("AutoSave", 300, 300);
    }

    private void Update()
    {
        if (continueLoadUser) {
            cloudSave.LoadUser(infomation.userId, localData);
            continueLoadUser = false;
        }
        if (connectionChecked) {
            if (isConnected) {
                if (continueSave) {
                    if (lastSavedInternet == 1 || (localData.Equals(data))) {
                        LoadFromData(data);
                    }
                    else {
                        loadSavePanel.SetActive(true);
                    }
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

    public void LocalSaveButtonPressed() {
        loadSavePanel.SetActive(false);
        LoadFromData(localData);
    }

    public void CloudSaveButtonPressed() {
        loadSavePanel.SetActive(false);
        LoadFromData(data);
    }

    //disable this for offline testing purposes
    private void OnApplicationPause(bool pause)
    {
        if (user.username.Length > 0) {
            Save();
        }
    }

    private void OnApplicationQuit()
    {
        if (user.username.Length > 0) {
            Save();
        }
    }

    public void Save()
    {
        if (gameObject.GetComponent<CatGameFlags>().firstLoad == 1) {
            //saves the data using save helper to turn info into a string that can be put in playerprefs
            infomation.catPower = gameObject.GetComponent<User>().catPower;
            infomation.minerals = gameObject.GetComponent<User>().minerals;
            infomation.food = gameObject.GetComponent<User>().food;
            infomation.roomDepth = gameObject.GetComponent<User>().roomDepth;

            infomation.discoveredCats = CatList.getInstance().discoveredCats;

            //rooms
            gameObject.GetComponent<BuildRoom>().RefreshRooms();

            infomation.rooms = gameObject.GetComponent<BuildRoom>().rooms;//RENAME RESEARCHING TO ACTIVE
            infomation.roomCount = gameObject.GetComponent<BuildRoom>().roomCount;

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
            string userId = gameObject.GetComponent<User>().userId;
            infomation.userId = userId;
            infomation.password = gameObject.GetComponent<User>().password;
            infomation.email = gameObject.GetComponent<User>().email;
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
            infomation.artifactTutorial = gameObject.GetComponent<CatGameFlags>().artifactTutorial;

            infomation.triesSinceLastAd = adController.timeSinceLastAd;

            infomation.crazyCatCounter = gameObject.GetComponent<GameProgression>().crazyCatCounter;

            RoomExcavation roomExcavation = gameObject.GetComponent<BuildRoom>().excavationRoomCopy.GetComponent<RoomExcavation>();
            infomation.excavationRoomSave = new ExcavationSave(roomExcavation.timeLength, roomExcavation.initialLength, roomExcavation.researching, roomExcavation.researchTitle, gameObject.GetComponent<BuildRoom>().excavationRoomCopy.transform.position.y);
            infomation.emptyRooms = gameObject.GetComponent<BuildRoom>().ReturnEmptyRooms();

            string data = SaveHelper.Serialise<SaveInfomation>(infomation);

            PlayerPrefs.SetString("Save Info", data);
            //Debug.Log(data);
            cloudSave.WriteNewUser(data, userId);

            if (!isConnected) {
                PlayerPrefs.SetInt("Last Saved Via Internet", 0);
            }
            else {
                PlayerPrefs.SetInt("Last Saved Via Internet", 1);
            }
        }
    }

    public void Load() {
        user = gameObject.GetComponent<User>();
        buildRoom = gameObject.GetComponent<BuildRoom>();

        //loads data from playerprefs and uses the save helper to translate the info back into the save infomation script
        if (PlayerPrefs.HasKey("Save Info")) {
            localData = PlayerPrefs.GetString("Save Info");
            infomation = SaveHelper.Deserialise<SaveInfomation>(localData);
            gameObject.GetComponent<AuthenicateUser>().saveLoadManager = this;
            gameObject.GetComponent<AuthenicateUser>().LoadUserFromSave(infomation.email, infomation.password);
            //Debug.Log(localData);
            string userId = infomation.userId;
        }
        else {//if there is no save infomation makes a new blank save
            infomation = new SaveInfomation();
            gameObject.GetComponent<WelcomeScreenControl>().CheckWelcome();
        }
    }

    public void LoadFromData(string data) {
        infomation = SaveHelper.Deserialise<SaveInfomation>(data);
        //Debug.Log("Cloud Save Data was different" + data);
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
        gameObject.GetComponent<CatGameFlags>().artifactTutorial = infomation.artifactTutorial;

        //materials
        user.catPower = infomation.catPower;
        user.food = infomation.food;
        user.minerals = infomation.minerals;
        user.roomDepth = infomation.roomDepth;

        CatList.getInstance().discoveredCats = infomation.discoveredCats;
        buildRoom.rooms = infomation.rooms;
        buildRoom.roomCount = infomation.roomCount;

        buildRoom.LoadRooms();
        buildRoom.LoadEmptyRooms(infomation.emptyRooms);

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
        gameObject.GetComponent<User>().userId = infomation.userId;
        user.password = infomation.password;
        user.email = infomation.email;
        gameObject.GetComponent<User>().highScore = infomation.highScore;

        adController.timeSinceLastAd = infomation.triesSinceLastAd;

        gameObject.GetComponent<GameProgression>().crazyCatCounter = infomation.crazyCatCounter;

        gameObject.GetComponent<BuildRoom>().buildExcavationRoomCopy(infomation.excavationRoomSave);

        return username;
    }


}
