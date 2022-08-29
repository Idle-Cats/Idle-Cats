using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRoom : MonoBehaviour
{
    //nathan is here
    //he says we suck
    //this is a skeleton class for timed rooms
    private float timer = 0.0f;
    private bool researching = false;
   
    // Start is called before the first frame update
    void Start()
    {
        //set up choices of rooms?
        //set up various options?
        //placeholder:
        this.timer = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        //have button
        //if button pressed
        //block out button, set researching to true
        researching = true;
        timer--;
        if (timer <= 0)
        {
            researching = false;
            //button for collect
            //apply results
        }
        

    }
}
