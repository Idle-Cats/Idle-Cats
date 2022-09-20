using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public GameObject CatPanel;
    public GameObject OpenCatList;

    public GameObject Cat;

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

    public void addCat(GameObject prefab) {
        // hide cat panel
        hideCatPanel();
        // add cat prefab to screen
        GameObject cat = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        cat.SetActive(true);
    }
}
