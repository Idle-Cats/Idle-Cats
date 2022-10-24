using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTestHelper
{

    public void Save(SaveInfomation info) {
        SaveInfomation infomation = info;

        string data = SaveHelper.Serialise<SaveInfomation>(infomation);

        PlayerPrefs.SetString("Save Info", data);
    }

    public SaveInfomation Load() {
        string data = PlayerPrefs.GetString("Save Info");
        SaveInfomation infomation = SaveHelper.Deserialise<SaveInfomation>(data);

        return infomation;
    }
}
