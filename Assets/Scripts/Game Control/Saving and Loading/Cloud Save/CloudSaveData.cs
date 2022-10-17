using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class CloudSaveData : MonoBehaviour
{
    public string data = "test";
    DatabaseReference reference;

    [SerializeField]
    private SaveLoadManager saveLoadManager;

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
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        CloudSaveData cloudSave = new CloudSaveData(data);
        string json = JsonUtility.ToJson(cloudSave);

        reference.Child("users").Child(username).SetRawJsonValueAsync(json);
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
        });
    }

    public void CheckProfile(string username)
    {
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

                saveLoadManager.continueSave = true;
                saveLoadManager.data = data;
            }
            if (!task.Result.Exists) {
                DataSnapshot snapshot = task.Result;
                gameObject.GetComponent<GameProgression>().CheckWelcome();
            }
        });
    }
}
