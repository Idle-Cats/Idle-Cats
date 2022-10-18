using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Notifications.Android;

public class Notifications : MonoBehaviour
{
    string[] text = {
        "Come back! Your cats are waiting!",
        "Time to get a collecting",
        "The apolocaplse can't wait. Come back!",
        "Your resources are fulling up, come back to collect!"
    };

    // Start is called before the first frame update
    void Start()
    {
        // //Remove notification
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationPause(bool pauseStatus) {
        MakeQuitNotifications();
        MakeCollectionReminder();
    }

    void OnApplicationQuit() {
        MakeQuitNotifications();
        MakeCollectionReminder();
    }

    void MakeQuitNotifications() {
        var date = System.DateTime.Now.AddHours(5);
        if(date.Hour >= 12 || date.Hour < 8) {
            date.AddDays(1);
            TimeSpan ts = new TimeSpan(8, 0, 0);
            date = date.Date + ts;
        }

        var channel = new AndroidNotificationChannel(){
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic Notification",
        };   
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification =  new AndroidNotification();
        notification.Title = "Come back";
        notification.Text = getRandom();
        notification.LargeIcon = "main_icon";

        notification.FireTime = date;

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        //check if any notifications have already been sent out
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled) {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
    }

    void MakeCollectionReminder() {
        BuildRoom room = gameObject.GetComponent<BuildRoom>();
        float resourcesLeft = 0.0f;
        float genPerSec = 0.0f;
        int secondsTillFull = 0;
        if (room.roomCount > 0) {
            ResourceRoom resourceRoom = room.rooms[0].getRoom().GetComponent<ResourceRoom>();
            float currCap = resourceRoom.roomCapacity;
            float inv = resourceRoom.roomInvent;
            resourcesLeft = currCap - inv;
            genPerSec = resourceRoom.GetCurrentBoost();
        }

        if (resourcesLeft > 0.0f && genPerSec > 0.0f) {
            secondsTillFull = (int) (resourcesLeft / genPerSec);
        }

        Debug.Log(resourcesLeft + " : " + genPerSec + " : " + secondsTillFull);

        var date = System.DateTime.Now.AddSeconds(secondsTillFull);

        var channel = new AndroidNotificationChannel(){
            Id = "channel_id2",
            Name = "Default Channel2",
            Importance = Importance.Default,
            Description = "Generic Notification",
        };   
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification =  new AndroidNotification();
        notification.Title = "Your resource room is full!";
        notification.Text = "Come back! Your room is at max capacity.";
        notification.LargeIcon = "main_icon";

        notification.FireTime = date;

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id2");

        //check if any notifications have already been sent out
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled) {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id2");
        }
    }

    string getRandom() {
        System.Random rand = new System.Random();
        int index = rand.Next(text.Length);
        return text[index];
    }
}
