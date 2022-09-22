using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSetText : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetText(string text) {
        this.text.SetText(text);
    }
}
