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
                    if (draggedObject.layer == 3 || draggedObject.layer == 8) {
                        if (hit.collider != null) {
                            if (draggedObject.layer == 8) {
                                draggedObject.GetComponent<ArtifactsBoost>().RemoveBoost();
                            }
                            if (draggedObject.layer == 3) {
                                Debug.Log("identifier: " + draggedObject.GetComponent<CatBoostRooms>());
                                // draggedObject.GetComponent<CatBoostRooms>().RemoveCatBoost();
                            }
                            draggedObject.GetComponent<CurrentRoom>().currentRoom = hit.collider.gameObject;
                            draggedObject.transform.position = hit.collider.gameObject.transform.position;
                            if (draggedObject.layer == 8) {
                                draggedObject.GetComponent<ArtifactsBoost>().ApplyBoost();
                            }
                            if (draggedObject.layer == 3) {
                                if(draggedObject != null) {
                                    Debug.Log("identifier: " + draggedObject.GetComponent<CatBoostRooms>());
                                    draggedObject.GetComponent<CatBoostRooms>().ApplyCatBoost();
                                }
                                // draggedObject.GetComponent<CatBoostRooms>().ApplyCatBoost();
                            }
                        }
                        else if (draggedObject.GetComponent<CurrentRoom>().currentRoom == null) {
                        }
                        else {
                            draggedObject.transform.position = draggedObject.GetComponent<CurrentRoom>().currentRoom.transform.position;
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
