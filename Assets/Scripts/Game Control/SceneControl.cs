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
    //show main game (keanna for now cause testing)
    public void GameScene() {  
        SceneManager.LoadScene("KeannaScene");  
    }
}
