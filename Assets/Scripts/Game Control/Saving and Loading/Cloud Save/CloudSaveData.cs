using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class CloudSaveData : MonoBehaviour
{
    public string data = "test";
    DatabaseReference reference;

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

    public void LoadUser()
    {
        reference.GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted) {
              // Handle the error...
              Debug.Log("Error in getting data");
          }
          else if (task.IsCompleted) {
              DataSnapshot snapshot = task.Result;
              // Do something with snapshot...
              Debug.Log("Snapshot: " + snapshot);
          }
      });
    }
}
