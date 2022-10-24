using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class CloudSaveData : MonoBehaviour
{
    public string data = "test";
    DatabaseReference reference;

    bool connectionCheckedProper = false;

    private SaveLoadManager saveLoadManager;
    private GameProgression gameProgression;
    private WelcomeScreenControl welcomeScreenControl;

    public void SetSaveLoadManager(SaveLoadManager saveLoadManager) {
        this.saveLoadManager = saveLoadManager;
    }

    public void SetGameProgression(GameProgression gameProgression) {
        this.gameProgression = gameProgression;
    }

    public void SetWelcoemScreenControl(WelcomeScreenControl welcomeScreenControl)
    {
        this.welcomeScreenControl = welcomeScreenControl;
    }

    private void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public CloudSaveData()
    {

    }

    public CloudSaveData(string data)
    {
        this.data = data;
    }

    public void WriteNewUser(string data, string username)
    {
        if (username.Length > 0) {
            reference = FirebaseDatabase.DefaultInstance.RootReference;
            CloudSaveData cloudSave = new CloudSaveData(data);
            string json = JsonUtility.ToJson(cloudSave);

            reference.Child("users").Child(username).SetRawJsonValueAsync(json);
        }
    }

    public void LoadUser(string username, string localData)
    {
        //Debug.Log("Loading from Cloud");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance.GetReference("users").Child(username).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted) {
                //Debug.Log("Error in getting data");
            }
            else if (task.IsCompleted) {
                DataSnapshot snapshot = task.Result;
                //Debug.Log("Data: " + data);
                if (!snapshot.Exists) {
                    //Debug.Log("cloud save no exist");
                    saveLoadManager.continueSave = true;
                    saveLoadManager.data = localData;
                }
                else if (!data.Equals(localData)) {
                    data = snapshot.Child("data").Value.ToString();
                    saveLoadManager.continueSave = true;
                    saveLoadManager.data = data;
                }
                else {
                    data = snapshot.Child("data").Value.ToString();
                    saveLoadManager.continueSave = true;
                    saveLoadManager.data = localData;
                }
            }
            else if (task.IsCanceled) {
                //Debug.Log("Task Cancelled");
            }
        });
    }

    public void CheckProfile(string username)
    {
        //Debug.Log("Checking if profile already exists");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance.GetReference("users").Child(username).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted) {
                //Debug.Log("Error in getting data");
            }
            else if (task.IsCompleted) {
                //Debug.Log("Task Completed");
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists) {
                    //Debug.Log("exists");
                }
                else {
                    //Debug.Log("dosent exist");
                    gameProgression.cloudCheckWelcome = true;
                }
                data = snapshot.Child("data").Value.ToString();
                //Debug.Log("Data: " + data);

                saveLoadManager.continueSave = true;
                saveLoadManager.data = data;
            }
        });
    }

    public void CheckConnection() {
        StartCoroutine("RunConnectionCheck");
    }

    private IEnumerator RunConnectionCheck() {
        yield return new WaitForSeconds(0.5f);

        DatabaseReference connectedRef = FirebaseDatabase.DefaultInstance.GetReference(".info/connected");

        connectedRef.ValueChanged += (object sender, ValueChangedEventArgs a) =>
        {
            if (!connectionCheckedProper) {
                bool isConnected = (bool)a.Snapshot.Value;
                //Debug.Log("Is Connected: " + isConnected);
                saveLoadManager.isConnected = isConnected;
                if (isConnected) {
                    connectionCheckedProper = true;
                }
                saveLoadManager.connectionChecked = true;
                welcomeScreenControl.isConnected = isConnected;
                welcomeScreenControl.connetionChecked = true;
            }
        };
    }
}
