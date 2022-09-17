using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Formatter;
using static GameControl;

public class FoodUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "F: " + formatValue(Food);
    }

    // Update is called once per frame
    void Update()
    {
        Food += 10;
        GetComponent<TextMeshProUGUI>().text = "F: " + formatValue(Food);
    }
}
