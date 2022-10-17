using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class CloudSaveData : MonoBehaviour
{
    public string data = "test";
    DatabaseReference reference;

    private SaveLoadManager saveLoadManager;
    private GameProgression gameProgression;

    public void SetSaveLoadManager(SaveLoadManager saveLoadManager) {
        this.saveLoadManager = saveLoadManager;
    }

    public void SetGameProgression(GameProgression gameProgression) {
        this.gameProgression = gameProgression;
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
        Debug.Log("Loading from Cloud");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance.GetReference("users").Child(username).Child("data").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted) {
                Debug.Log("Error in getting data");
            }
            else if (task.IsCompleted) {
                DataSnapshot snapshot = task.Result;
                data = snapshot.Value.ToString();
                Debug.Log("Data: " + data);
                if (!data.Equals(localData)) {
                    saveLoadManager.continueSave = true;
                    saveLoadManager.data = data;
                }
                else {
                    saveLoadManager.continueSave = true;
                    saveLoadManager.data = localData;
                }
            }
            else if (task.IsCanceled) {
                Debug.Log("Task Cancelled");
            }
        });
    }

    public void CheckProfile(string username)
    {
        Debug.Log("Checking if profile already exists");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance.GetReference("users").Child(username).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted) {
                Debug.Log("Error in getting data");
            }
            else if (task.IsCompleted) {
                Debug.Log("Task Completed");
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists) {
                    Debug.Log("exists");
                }
                else {
                    Debug.Log("dosent exist");
                    gameProgression.cloudCheckWelcome = true;
                }
                data = snapshot.Child("data").Value.ToString();
                Debug.Log("Data: " + data);

                saveLoadManager.continueSave = true;
                saveLoadManager.data = data;
            }
        });
    }

    public void CheckConnection() {
        DatabaseReference connectedRef = FirebaseDatabase.DefaultInstance.GetReference(".info/connected");


    }
}
