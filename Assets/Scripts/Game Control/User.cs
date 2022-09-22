using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public int highScore;

    public string username;

    public int catPower = 0;
    public int food = 0;
    public int minerals = 0;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("SavingHighScore");
        username = PlayerPrefs.GetString("SavingUsername");
    }

    private void OnApplicationPause()
    {
        Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    // Update is called once per frame
    void Update()
    {
        int total = catPower + food + minerals;
        if (total > highScore) {
            highScore = total;
        }
    }

    void Save() {
        PlayerPrefs.SetInt("SavingHighScore", highScore);
        PlayerPrefs.SetString("SavingUsername", username);
    }
}
