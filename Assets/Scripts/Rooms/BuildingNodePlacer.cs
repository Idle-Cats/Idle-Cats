using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingNodePlacer : MonoBehaviour
{
    public GameObject nodePrefab;

    public GameObject node;
    
    public int nodeLength;

    public BuildRoom buildRoom;

    [SerializeField]
    private float roomHeight = 1;

    void Start()
    {
        if (node == null) {
            nodeLength = -1;

            placeNode();
        }
    }

    public void placeNode() {
        roomHeight = buildRoom.roomHeight;
        nodeLength++;
        GameObject newNode = Instantiate(nodePrefab, new Vector2(0, -1.6f - (roomHeight * 1.5f * nodeLength)), Quaternion.identity);
        Destroy(node);
        node = newNode;
    }

    public void LoadNode(float nodeY) {
        GameObject newNode = Instantiate(nodePrefab, new Vector2(0, nodeY), Quaternion.identity);
        node = newNode;
    }
}
