using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgression : MonoBehaviour
{
    public Flags flags;

    public GameObject welcome_panel;
    public GameObject milestone1;
    public GameObject milestone2;
    public GameObject milestone3;
    public GameObject milestone4;
    public GameObject milestone5;
    public GameObject milestone6;
    public GameObject milestone7;
    public GameObject milestone8;
    public GameObject milestone9;
    public GameObject milestone10;
    public GameObject milestone11;
    public GameObject milestone12;
    public GameObject milestone13;

    // Start is called before the first frame update
    void Start()
    {
        if (!flags.first_load) {
            ShowWelcome();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWelcome() {
        welcome_panel.SetActive(false);
    }

    void ShowWelcome() {
        welcome_panel.SetActive(true);
        flags.first_load = true;
    }

    public void CloseMilestone1() {
        milestone1.SetActive(false);
    }

    void ShowMilestone1() {
        milestone1.SetActive(true);
    }

    public void CloseMilestone2() {
        milestone2.SetActive(false);
    }

    void ShowMilestone2() {
        milestone2.SetActive(true);
    }

    public void CloseMilestone3() {
        milestone3.SetActive(false);
    }

    void ShowMilestone3() {
        milestone3.SetActive(true);
    }

    public void CloseMilestone4() {
        milestone4.SetActive(false);
    }

    void ShowMilestone4() {
        milestone4.SetActive(true);
    }

    public void CloseMilestone5() {
        milestone5.SetActive(false);
    }

    void ShowMilestone5() {
        milestone5.SetActive(true);
    }

    public void CloseMilestone6() {
        milestone6.SetActive(false);
    }

    void ShowMilestone6() {
        milestone6.SetActive(true);
    }

    public void CloseMilestone7() {
        milestone7.SetActive(false);
    }

    void ShowMilestone7() {
        milestone7.SetActive(true);
    }

    public void CloseMilestone8() {
        milestone8.SetActive(false);
    }

    void ShowMilestone8() {
        milestone8.SetActive(true);
    }

    public void CloseMilestone9() {
        milestone9.SetActive(false);
    }

    void ShowMilestone9() {
        milestone9.SetActive(true);
    }

    public void CloseMilestone10() {
        milestone10.SetActive(false);
    }

    void ShowMilestone10() {
        milestone10.SetActive(true);
    }

    public void CloseMilestone11() {
        milestone11.SetActive(false);
    }

    void ShowMilestone11() {
        milestone11.SetActive(true);
    }

    public void CloseMilestone12() {
        milestone12.SetActive(false);
    }

    void ShowMilestone12() {
        milestone12.SetActive(true);
    }

    public void CloseMilestone13() {
        milestone13.SetActive(false);
    }

    void ShowMilestone13() {
        milestone13.SetActive(true);
    }
}
