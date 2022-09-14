using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Formatter;
using static GameControl;

public class CoinsUpdater : MonoBehaviour
{
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
