using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcavationSave
{
    public int timeLength;
    public int initialLength;

    public int researching;
    public string researchTitle;

    public float posY;

    public ExcavationSave()
    {

    }

    public ExcavationSave(int timeLength, int initialLength, bool researching, string researchTitle, float posY)
    {
        this.timeLength = timeLength;
        this.initialLength = initialLength;
        if (researching) {
            this.researching = 1;
        }
        else {
            this.researching = 0;
        }
        this.researchTitle = researchTitle;
        this.posY = posY;
    }
}
