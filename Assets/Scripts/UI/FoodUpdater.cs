using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Formatter;

public class FoodUpdater : MonoBehaviour
{
    // Change once Game Provider is created
    public int Food = 0;

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
