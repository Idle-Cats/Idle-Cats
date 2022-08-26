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
        PlayerPrefs.SetString("Save Info", SaveHelper.Serialise<SaveInfomation>(infomation));
        Debug.Log(SaveHelper.Serialise<SaveInfomation>(infomation));
    }

    public void Load() {
        //loads data from playerprefs and uses the save helper to translate the info back into the save infomation script
        if (PlayerPrefs.HasKey("Save Info")) {
            infomation = SaveHelper.Deserialise<SaveInfomation>(PlayerPrefs.GetString("Save Info"));
        }
        else {//if there is no save infomation makes a new blank save
            infomation = new SaveInfomation();
            Save();
        }
    }
}
