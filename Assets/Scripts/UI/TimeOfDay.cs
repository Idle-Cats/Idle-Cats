using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeOfDay : MonoBehaviour
{

    TimeSpan morning = new TimeSpan(6, 0, 0);
    TimeSpan evening = new TimeSpan(18, 0, 0);
    public Sprite day;
    public Sprite night; 
    

    // Start is called before the first frame update
    void Start()
    {
        TimeSpan now = DateTime.Now.TimeOfDay;
        if (now > morning && now < evening)
        {
            GetComponent<SpriteRenderer>().sprite = day;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = night;
        }
        
    }

}
