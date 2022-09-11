using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Formatter;

public class CoinsUpdater : MonoBehaviour
{
    // Change once Game Provider is created
    public int Coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "C: " + formatValue(Coins);
    }

    // Update is called once per frame
    void Update()
    {
        Coins += 1;
        GetComponent<TextMeshProUGUI>().text = "C: " + formatValue(Coins);
    }
}
