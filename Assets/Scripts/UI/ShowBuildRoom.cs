using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBuildRoom : MonoBehaviour
{
    public GameObject buildRoomPanel;

    private bool panelShown = false;

    public void RunShowBuildRoom() {
        if (panelShown) {
            panelShown = false;
            buildRoomPanel.SetActive(false);
        }
        else {
            panelShown = true;
            buildRoomPanel.SetActive(true);
        }
    }
}
