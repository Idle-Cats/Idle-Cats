using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoom : MonoBehaviour
{
    public GameObject testRoom;

    private int roomCount = 0;

    public float roomHeight;

    void Start()
    {
        roomHeight = testRoom.GetComponent<SpriteRenderer>().size.y;
    }

    public void placeTestRoom() {
        GameObject room = Instantiate(testRoom, gameObject.GetComponent<BuildingNodePlacer>().node.transform.position, Quaternion.identity);
        room.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        roomCount++;
        gameObject.GetComponent<BuildingNodePlacer>().placeNode();
    }
}
