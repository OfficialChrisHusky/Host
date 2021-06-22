using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float defaultMovementSpeed;
    public float speedMultiplier;
    public bool canMove;
    public float movementSpeed;

    Rigidbody body;

    private void Start() {

        body = GetComponent<Rigidbody>();

        movementSpeed = defaultMovementSpeed;
        
    }

    private void Update() {

        if(canMove) {

            if(Input.GetKey(KeyCode.LeftShift)) {

                movementSpeed = defaultMovementSpeed * speedMultiplier;

            } else {

                movementSpeed = defaultMovementSpeed;

            }

            float x = Input.GetAxisRaw("Horizontal") * movementSpeed;
            float y = Input.GetAxisRaw("Vertical") * movementSpeed;

            Vector3 movePos = transform.right * x + transform.forward * y;
            movePos.y = body.velocity.y;

            body.velocity = movePos;

        }
        
    }

}
