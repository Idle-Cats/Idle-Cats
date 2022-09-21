using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class WelcomeScreen : MonoBehaviour
{
    public void assignName() {
        
        string name = GameObject.Find("Username Input").GetComponent<TMP_InputField>().text;
        if (name.Length < 1) {
            return;
        }
        GameObject.Find("Game Control").GetComponent<User>().username = name;
        GameObject.Find("Game Control").GetComponent<CatGameFlags>().first_load = 1;
        GameObject.Find("Game Control").GetComponent<SceneControl>().GameScene();
    }
}
