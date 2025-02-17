using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Android;
public class NotificationManager : MonoBehaviour
{
    private const string ChannelId = "channel_id";


    private void Start()
    {
        /*CheckNotificationIntentData();
        RegisterNotificationChannel();
        AndroidNotificationCenter.OnNotificationReceived += OnNotificationRevied;*/
    }

    private void CheckNotificationIntentData()
    {
        var notificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();
        if (notificationIntentData != null)
        {
            var id = notificationIntentData.Id;
            var channel = notificationIntentData.Channel;
            var notification = notificationIntentData.Notification;

            var msg = "Notification IntentData : id: " + id;
            msg += "\n .channel: " + channel;
            msg += "\n .notification: " + notification;
            Debug.Log(msg);
        }
    }

    private void OnNotificationRevied(AndroidNotificationIntentData data)
    {
        var msg = "Notification received : " + data.Id + "\n";
        msg += "\n Notification received: ";
        msg += "\n .Title: " + data.Notification.Title;
        msg += "\n .Body: " + data.Notification.Text;
        msg += "\n .Channel: " + data.Channel;
        Debug.Log(msg);
    }
    
    private void RegisterNotificationChannel()
    {
        var c = new AndroidNotificationChannel()
        {
            Id = ChannelId,
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
    }

    public void OnClickedNotification()
    {
        if(GameManager.instance.OnAlert == true)
        {
            var notification = new AndroidNotification();
            notification.Title = "미오에서 알려요";
            notification.Text = "작물성장이 완료되었어요";

            notification.SmallIcon = "app_icon_1";
            notification.LargeIcon = "app_icon_l0";

            notification.IntentData = "{\"title\": \"Notification 1\", \"data\": \"200\"}";

            AndroidNotificationCenter.SendNotification(notification, ChannelId);
        }
    }
}
