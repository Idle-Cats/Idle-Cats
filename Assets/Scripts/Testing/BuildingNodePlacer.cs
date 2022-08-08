using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingNodePlacer : MonoBehaviour
{
    public GameObject nodePrefab;

    public GameObject node;
    [SerializeField]
    private int nodeLength;

    [SerializeField]
    private int roomHeight = 1;

    void Start()
    {
        node = null;
        nodeLength = 0;

        placeNode();
    }

    public void placeNode() {
        GameObject newNode = Instantiate(nodePrefab, new Vector2(0, 4 - (roomHeight * nodeLength)), Quaternion.identity);
        Destroy(node);
        node = newNode;
        nodeLength++;
    }
}
