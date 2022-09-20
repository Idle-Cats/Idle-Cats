using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WelcomeScreen : MonoBehaviour
{

    private GameObject gameControl;

    void Awake() {
        gameControl = GameObject.Find("Game Control");
        CatGameFlags flags = gameControl.GetComponent<CatGameFlags>();
        if (flags.first_load == 0) {
            gameControl.GetComponent<SceneControl>().WelcomeScene();
        }
    }

    public void assignName() {
        string name = GameObject.Find("Username Input").GetComponent<TMP_InputField>().text;
        CatGameFlags flags = gameControl.GetComponent<CatGameFlags>();
        flags.first_load = 1;
        gameControl.GetComponent<User>().username = name;
        gameControl.GetComponent<SceneControl>().GameScene();
    }
}
