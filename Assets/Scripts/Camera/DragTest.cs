using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTest : MonoBehaviour
{
    public GameObject gameControl;

    private Camera cam;

    [SerializeField]
    private GameObject draggedObject;

    public bool draggingObject = false;

    public int dragFingerId = -1;

    // Start is called before the first frame update
    void Start()
    {
       cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                Vector2 fingerPos = touch.position;
                Vector3 firePoint = cam.ScreenToWorldPoint(new Vector3(fingerPos.x, fingerPos.y, 0));

                RaycastHit2D hit = Physics2D.Raycast(firePoint, Vector3.forward, 20);
                Debug.DrawRay(firePoint, Vector3.forward * 20, Color.red, 5, false);
                if (hit.collider != null) {
                    print(hit.collider.gameObject);
                    if (hit.collider.gameObject.tag == "Draggable") {
                        draggedObject = hit.collider.gameObject;
                        draggingObject = true;
                        dragFingerId = touch.fingerId;
                    }
                }
            }
            if (touch.phase == TouchPhase.Ended) {
                if (draggingObject && touch.fingerId == dragFingerId) {
                    Vector2 fingerPos = touch.position;
                    Vector3 firePoint = cam.ScreenToWorldPoint(new Vector3(fingerPos.x, fingerPos.y, 0));

                    int layermask = 1 << 6;

                    RaycastHit2D hit = Physics2D.Raycast(firePoint, Vector3.forward, 20, layermask);
                    Debug.DrawRay(firePoint, Vector3.forward * 20, Color.green, 5, false);
                    //Layer 3 = cat
                    //Layer 8 = room
                    //Is cat or room
                    print(draggedObject);
                    if (draggedObject.layer == 3 || draggedObject.layer == 8) {
                        //If hit something
                        if (hit.collider != null) {
                            //Dragging object is room
                            if (draggedObject.layer == 8) {
                                if (draggedObject.GetComponent<CurrentRoom>().currentRoom != null) {
                                    draggedObject.GetComponent<ArtifactsBoost>().RemoveBoost();
                                }
                                draggedObject.GetComponent<CurrentRoom>().currentRoom = hit.collider.gameObject;
                                draggedObject.GetComponent<ArtifactsBoost>().ApplyBoost();

                            } else { //Dragging object is cat
                                //Switch or remove cat from room
                                GameObject objectHit = hit.collider.gameObject;
                                CurrentRoom currentRoomRef = draggedObject.GetComponent<CurrentRoom>();
                                //Remove cat from room
                                if (currentRoomRef.currentRoom != null) { //Cat has a room
                                    //Remove cat from current room
                                    draggedObject.GetComponent<CatBoostRooms>().RemoveCatBoost();
                                    currentRoomRef.currentRoom.GetComponent<RoomInformation>().containsCat = false;
                                    currentRoomRef.currentRoom = null;
                                }

                                //If hit object is a room then add cat to that room
                                RoomInformation roomInfo = objectHit.GetComponent<RoomInformation>();
                                if (roomInfo != null) {
                                    if (roomInfo.containsCat == false) {
                                        //Set cat's current room to the room it was dropped in
                                        currentRoomRef.currentRoom = objectHit;

                                        draggedObject.GetComponent<CatBoostRooms>().ApplyCatBoost();

                                        // set boolean in RoomInformation to true linking the cat to the room
                                        currentRoomRef.currentRoom.GetComponent<RoomInformation>().containsCat = true;

                                        //Set the cat to the rooms position
                                        draggedObject.transform.position = new Vector3(objectHit.transform.position.x, objectHit.transform.position.y, -1);
                                    }
                                }
                            }
                        } else { //Hits nothing
                            //Is cat
                            if (draggedObject.layer == 3) {
                                //Remove cat from room when dragged off room
                                CurrentRoom currentRoomRef = draggedObject.GetComponent<CurrentRoom>();
                                //Remove cat from room
                                if (currentRoomRef.currentRoom != null) { //Cat has a room
                                    //Remove cat from current room
                                    draggedObject.GetComponent<CatBoostRooms>().RemoveCatBoost();
                                    currentRoomRef.currentRoom.GetComponent<RoomInformation>().containsCat = false;
                                    currentRoomRef.currentRoom = null;
                                    print("Cat removed from room");
                                }
                            }
                        }
                    }

                    draggingObject = false;
                    draggedObject = null;
                    dragFingerId = -1;
                }
            }
            if (touch.phase == TouchPhase.Moved && touch.fingerId == dragFingerId) {
                if (draggingObject) {

                    Vector3 fingerPos = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

                    draggedObject.transform.position = new Vector2(fingerPos.x, fingerPos.y);
                }
            }
        }
    }
}
