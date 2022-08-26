using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChecker : MonoBehaviour
{
    SaveLoadManager saveLoadManager;

    public void Awake()
    {
        saveLoadManager = gameObject.GetComponent<SaveLoadManager>();

        //when the game opens starts the autosave thread in order to autosave every 5 mins
        StartCoroutine(autoSave(300));
    }

    public void OnApplicationPause(bool pause)
    {
        //Because android does not call onapplicationquit we use onapplicationpause to call the save function just before it closes
        saveLoadManager.Save();
    }

    IEnumerator autoSave(int saveTime) {
        while (true) {
            yield return new WaitForSeconds(saveTime);

            saveLoadManager.Save();
        }
    }
}
