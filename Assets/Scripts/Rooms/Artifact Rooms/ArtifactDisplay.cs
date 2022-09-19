using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArtifactDisplay : MonoBehaviour
{
    public Artifact artifact;

    public Image artworkImage;

    public GameObject nameText;

    // Start is called before the first frame update
    void Start()
    {
        if (artifact != null) {
            RefreshSelf();
        }
    }

    public void RefreshSelf() {
        artworkImage.sprite = artifact.image;
        nameText.GetComponent<TextMeshProUGUI>().SetText(artifact.name);
    }
}
