using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChecker : MonoBehaviour
{
    SaveLoadManager saveLoadManager;

    public void Awake()
    {
        saveLoadManager = gameObject.GetComponent<SaveLoadManager>();

        StartCoroutine(autoSave(300));
    }

    public void OnApplicationPause(bool pause)
    {
        saveLoadManager.Save();
    }

    IEnumerator autoSave(int saveTime) {
        while (true) {
            yield return new WaitForSeconds(saveTime);

            saveLoadManager.Save();
        }
    }
}
