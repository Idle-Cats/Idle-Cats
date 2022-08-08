using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoom : MonoBehaviour
{
    public GameObject testRoom;

    private int roomCount = 0;

    public void placeTestRoom() {
        Instantiate(testRoom, gameObject.GetComponent<BuildingNodePlacer>().node.transform.position, Quaternion.identity);
        roomCount++;
        gameObject.GetComponent<BuildingNodePlacer>().placeNode();
    }
}
