using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{

    public GameObject CatPanel;
    public GameObject OpenCatList;

    //show catlist
   public void ListScene() {  
        SceneManager.LoadScene("CatList");  
    }  
    //show main game (keanna for now cause testing)
    public void GameScene() {  
        SceneManager.LoadScene("KeannaScene");  
    }

    public void showCatPanel() 
    {
        OpenCatList.SetActive(false);
        CatPanel.SetActive(true);
    }

    public void hideCatPanel() 
    {
        OpenCatList.SetActive(true);
        CatPanel.SetActive(false);
    }
}
