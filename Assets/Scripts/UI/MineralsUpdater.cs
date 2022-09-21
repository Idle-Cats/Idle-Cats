using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Formatter;

public class MineralsUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject gameControl;

    private User user;

    // Start is called before the first frame update
    void Start()
    {
        user = gameControl.GetComponent<User>();
        GetComponent<TextMeshProUGUI>().text = "M: " + formatValue(user.minerals);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "M: " + formatValue(user.minerals);
    }
}
