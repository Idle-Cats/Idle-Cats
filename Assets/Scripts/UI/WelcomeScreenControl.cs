using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreenControl : MonoBehaviour
{


    void Awake() {
        GameObject gameControl = GameObject.Find("Game Control");
        CatGameFlags flags = gameControl.GetComponent<CatGameFlags>();
        if (flags.first_load == 0) {
            gameControl.GetComponent<SceneControl>().WelcomeScene();
        }
    }

    
}
