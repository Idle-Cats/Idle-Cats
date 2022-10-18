using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WelcomeScreenControl : MonoBehaviour
{
    public GameObject panel;
    public User user;
    public TMP_InputField input;

    public CloudSaveData cloud;
    public SaveLoadManager saveLoadManager;

    void Start() {
    }

    public void CheckWelcome() {//delday for saving loading
        CatGameFlags flags = gameObject.GetComponent<CatGameFlags>();
        if (flags.firstLoad == 0) {
            panel.SetActive(true);
        }
    }

    public void AssignName() {     
        string name = input.text;
        if (name.Length < 1) {
            return;
        }
        user.username = name;

        if (saveLoadManager.isConnected) {
            cloud.CheckProfile(name);
        }
        else {
            gameObject.GetComponent<GameProgression>().cloudCheckWelcome = true;
            saveLoadManager.continueSave = true;
            saveLoadManager.data = "";
        }

        panel.SetActive(false);
    }
}
