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

    public AuthenicateUser authenicateUser;

    public bool continueCreateUser = false;
    public bool continueLoadUser = false;

    public TMP_InputField newUserEmail;
    public TMP_InputField newUserPassword;

    public TMP_InputField oldUserEmail;
    public TMP_InputField oldUserPassword;

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

        gameObject.GetComponent<BuildRoom>().gameStarted = true;
    }

    public void CreateUser() {
        string name = input.text;
        if (name.Length < 1) {
            return;
        }
        user.username = name;
        
        if (saveLoadManager.isConnected) {
            authenicateUser.CreateUser(newUserEmail, newUserPassword);
        }
    }

    public void LoadUser() {
        if (saveLoadManager.isConnected) {
            authenicateUser.LoadUser(oldUserEmail, oldUserPassword);
        }
    }

    private void Update()
    {
        if (continueCreateUser) {
            string name = input.text;
            if (name.Length < 1) {
                return;
            }
            user.username = name;

            panel.SetActive(false);

            gameObject.GetComponent<GameProgression>().cloudCheckWelcome = true;
            gameObject.GetComponent<BuildRoom>().gameStarted = true;

            continueCreateUser = false;
        }
        if (continueLoadUser) {
            cloud.CheckProfile(user.userId);

            panel.SetActive(false);

            continueLoadUser = false;
        }
    }
}
