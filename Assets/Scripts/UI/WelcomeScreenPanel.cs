using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeScreenPanel : MonoBehaviour
{
    public GameObject newUserPanel;
    public GameObject loadUserPanel;
    public GameObject userChoicePanel;

    public GameObject errorText;

    public void ShowNewUserPanel() {
        newUserPanel.SetActive(true);
        errorText.SetActive(false);
    }

    public void HideNewUserPanel() {
        newUserPanel.SetActive(false);
        errorText.SetActive(false);
    }

    public void ShowLoadUserPanel()
    {
        loadUserPanel.SetActive(true);
        errorText.SetActive(false);
    }

    public void HideLoadUserPanel()
    {
        loadUserPanel.SetActive(false);
        errorText.SetActive(false);
    }

    public void ShowChoicePanel()
    {
        userChoicePanel.SetActive(true);
        errorText.SetActive(false);
    }

    public void HideChoicePanel()
    {
        userChoicePanel.SetActive(false);
        errorText.SetActive(false);
    }
}
