using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRoomSave
{
    public float timeLength;
    public float initialLength;

    public bool researching;

    public TimerRoomSave() {

    }

    public TimerRoomSave(float timeLength, float initialLength, bool researching)
    {
        this.timeLength = timeLength;
        this.initialLength = initialLength;
        this.researching = researching;
    }
}
