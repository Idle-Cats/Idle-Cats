using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingNodePlacer : MonoBehaviour
{
    public GameObject nodePrefab;

    [SerializeField]
    private GameObject[] nodeList;
    [SerializeField]
    private int nodeListLength;

    private int roomHeight = 5;

    void Start()
    {
        nodeList = new GameObject[5];
        nodeListLength = 0;

        placeNode();
    }

    public void placeNode() {
        if (nodeListLength == nodeList.Length) {
            expandCapacity();
        }
        GameObject newNode = Instantiate(nodePrefab, new Vector2(0, 4 - (roomHeight * nodeListLength)), Quaternion.identity);
        nodeList[nodeListLength] = newNode;
        nodeListLength++;
    }

    void expandCapacity() {
        GameObject[] newList = new GameObject[nodeList.Length * 3];
        for (int i = 0; i < nodeList.Length; i++) {
            newList[i] = nodeList[i];
        }
    }
}
