using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        DontDestroyOnLoad(gameObject);  

        //loads a save when it is opened
        Instance = this;
        Load();
    }

    public void Save()
    {
        //saves the data using save helper to turn info into a string that can be put in playerprefs
        infomation.discoveredCats = CatList.getInstance().discoveredCats;

        gameObject.GetComponent<BuildRoom>().RefreshRooms();

        infomation.rooms = gameObject.GetComponent<BuildRoom>().rooms;
        infomation.roomCount = gameObject.GetComponent<BuildRoom>().roomCount;
        infomation.nodeLength = gameObject.GetComponent<BuildingNodePlacer>().nodeLength;
        if (infomation.nodeLength > 0) {
            infomation.nodeY = gameObject.GetComponent<BuildingNodePlacer>().node.transform.position.y;
        }
        else {
            infomation.nodeY = 4;
        }


        PlayerPrefs.SetString("Save Info", SaveHelper.Serialise<SaveInfomation>(infomation));
        Debug.Log(SaveHelper.Serialise<SaveInfomation>(infomation));
    }

    public void Load() {
        //loads data from playerprefs and uses the save helper to translate the info back into the save infomation script
        if (PlayerPrefs.HasKey("Save Info")) {
            infomation = SaveHelper.Deserialise<SaveInfomation>(PlayerPrefs.GetString("Save Info"));
            Debug.Log(PlayerPrefs.GetString("Save Info"));

            CatList.getInstance().discoveredCats = infomation.discoveredCats;
            gameObject.GetComponent<BuildRoom>().rooms = infomation.rooms;
            gameObject.GetComponent<BuildRoom>().roomCount = infomation.roomCount;

            gameObject.GetComponent<BuildRoom>().LoadRooms();

            gameObject.GetComponent<BuildingNodePlacer>().nodeLength = infomation.nodeLength;
            gameObject.GetComponent<BuildingNodePlacer>().LoadNode(infomation.nodeY);

        }
        else {//if there is no save infomation makes a new blank save
            infomation = new SaveInfomation();
            Save();
        }
    }
}
