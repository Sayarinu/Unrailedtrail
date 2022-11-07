using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToMove : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 5f;

    Rigidbody rb;

    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();    
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }

        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0); // can make it an array if we want to add buffering touches to our game (probably
                                       // Unnecessarily complicated
            if (touch.phase == TouchPhase.Began) {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position); // moves the camera to the position (can set in a different script if we want)
                touchPosition.z = 0;
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector3(whereToMove.x * moveSpeed, 0, whereToMove.z * moveSpeed); // 0 is the y and we need to see if we use the y in our movement
            }
        }
        if (currentDistanceToTouchPos > previousDistanceToTouchPos) {
            isMoving = false;
            rb.velocity = Vector3.zero;
        }
        
        if (isMoving) {
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }
    }
}
