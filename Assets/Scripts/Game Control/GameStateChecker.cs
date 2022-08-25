using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChecker : MonoBehaviour
{
    SaveLoadManager saveLoadManager;

    public void Awake()
    {
        saveLoadManager = gameObject.GetComponent<SaveLoadManager>();
    }

    public void OnApplicationPause(bool pause)
    {
        saveLoadManager.Save();
    }
}
