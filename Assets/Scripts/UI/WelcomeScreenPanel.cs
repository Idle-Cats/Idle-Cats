using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeScreenPanel : MonoBehaviour
{
    public GameObject newUserPanel;
    public GameObject loadUserPanel;
    public GameObject userChoicePanel;

    public void ShowNewUserPanel() {
        newUserPanel.SetActive(true);
    }

    public void HideNewUserPanel() {
        newUserPanel.SetActive(false);
    }

    public void ShowLoadUserPanel()
    {
        loadUserPanel.SetActive(true);
    }

    public void HideLoadUserPanel()
    {
        loadUserPanel.SetActive(false);
    }

    public void ShowChoicePanel()
    {
        userChoicePanel.SetActive(true);
    }

    public void HideChoicePanel()
    {
        userChoicePanel.SetActive(false);
    }
}
