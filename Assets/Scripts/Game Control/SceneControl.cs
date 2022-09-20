using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  

public class SceneControl : MonoBehaviour
{
    //show catlist
   public void ListScene() {  
        SceneManager.LoadScene("CatList");
    }  
    //show main game
    public void GameScene() {  
        SceneManager.LoadScene("AlexLScene");
    }

    // Show welcome screen
    public void WelcomeScene() {  
        SceneManager.LoadScene("WelcomeScreen");
    }
}
