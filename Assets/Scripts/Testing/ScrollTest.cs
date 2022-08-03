using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTest : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 0.5f;

    private float top = 0;
    private float bottom = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Moved) {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (touch.deltaPosition.y * (-scrollSpeed/100)), -10);
                if (gameObject.transform.position.y > 0) {
                    gameObject.transform.position = new Vector3(transform.position.x, 0, -10);
                }
                else if (gameObject.transform.position.y < -bottom) {
                    gameObject.transform.position = new Vector3(transform.position.x, -bottom, -10);
                }
            }
        }
    }
}
