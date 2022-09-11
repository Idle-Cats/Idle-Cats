using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Formatter;

public class MineralsUpdater : MonoBehaviour
{
    // Change once Game Provider is created
    public int Minerals = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "M: " + formatValue(Minerals);
    }

    // Update is called once per frame
    void Update()
    {
        Minerals += 100;
        GetComponent<TextMeshProUGUI>().text = "M: " + formatValue(Minerals);
    }
}
