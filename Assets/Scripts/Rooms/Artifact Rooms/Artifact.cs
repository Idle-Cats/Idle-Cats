using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Artifact", menuName = "Artifact")]
public class Artifact : ScriptableObject
{
    public new string name;
    public float boost;

    public Sprite image;

    public BoostType boostType;

    public enum BoostType {
        resourceBoost,
        timedBoost,
        resourceMax
    }
}
