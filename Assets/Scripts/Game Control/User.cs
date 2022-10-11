using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class User : MonoBehaviour
{
    public int highScore;

    public string username;

    public int catPower = 0;
    public int food = 0;
    public int minerals = 0;

    public TextMeshProUGUI usernameObject;

    // Update is called once per frame
    void Update()
    {
        int total = catPower + food + minerals;
        if (total > highScore) {
            highScore = total;
        }

        usernameObject.SetText("Username: " + username);
    }
}
