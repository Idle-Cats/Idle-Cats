using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System;

public class TimeOfDayTest 
{

    TimeSpan morning = new TimeSpan(6, 0, 0);
    TimeSpan evening = new TimeSpan(18, 0, 0);
    public Sprite day;
    public Sprite night; 

    [Test]
    public void isDaytime() {
        //TimeSpan now = DateTime.Now.TimeOfDay;
        TimeSpan now = new TimeSpan(7, 0, 0);
        bool isDay;
        if (now > morning && now < evening)
        {
            isDay = true;
        }
        else
        {
            isDay = false;
        }

        // Will fail if test is run at night
        Assert.True(isDay);
    }
}
