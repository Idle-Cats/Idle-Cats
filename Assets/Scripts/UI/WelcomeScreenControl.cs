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

    public WelcomeScreenPanel welcomeScreenPanel;
    public bool isConnected = false;
    public bool connetionChecked = false;

    public TMP_Text errorText;
    public GameObject errorTextObject;

    public GameObject confirmButtonCreate;
    public GameObject confurmButtonLoad;

    public bool userExistsChecked = false;

    public bool userDosentExistsChecked = false;

    void Start() {
        cloud.SetWelcoemScreenControl(this);
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
        confirmButtonCreate.SetActive(false);
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
        confurmButtonLoad.SetActive(false);
        if (saveLoadManager.isConnected) {
            authenicateUser.LoadUser(oldUserEmail, oldUserPassword);
        }
    }

    private void Update()
    {
        if (connetionChecked) {
            if (isConnected) {
                welcomeScreenPanel.ShowChoicePanel();
                connetionChecked = false;
                errorText.SetText("");
                errorTextObject.SetActive(false);
            }
            else {
                errorText.SetText("Please restart and connect to internet");
                errorTextObject.SetActive(true);
            }
            connetionChecked = false;
        }
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
        if (userExistsChecked) {
            errorText.SetText("User Already Exists");
            errorTextObject.SetActive(true);
            confirmButtonCreate.SetActive(true);
            userExistsChecked = false;
        }
        if (userDosentExistsChecked) {
            errorText.SetText("Username or Password was incorrect");
            errorTextObject.SetActive(true);
            confurmButtonLoad.SetActive(true);
            userDosentExistsChecked = false;
        }
    }
}
