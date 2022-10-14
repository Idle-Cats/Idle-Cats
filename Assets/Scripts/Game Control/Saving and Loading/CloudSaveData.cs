using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSaveData
{
    public string data;

    public void Save(string data) {
        this.data = data;
    }

    public string Load() {
        return data;
    }

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static CloudSaveData Parse(string json)
    {
        return JsonUtility.FromJson<CloudSaveData>(json);
    }
}
