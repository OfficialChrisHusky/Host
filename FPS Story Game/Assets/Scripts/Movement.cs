using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float defaultMovementSpeed;
    public float speedMultiplier;
    public float jumpHeight;
    public bool canMove;
    public bool isGrounded;
    public float movementSpeed;
    public LayerMask mask;

    Rigidbody body;

    private void Start() {

        body = GetComponent<Rigidbody>();

        movementSpeed = defaultMovementSpeed;
        
    }

    private void Update() {

        if(canMove) {

            isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y + 0.25f), transform.position.z), 0.4f, mask);

            if(isGrounded && Input.GetKeyDown(KeyCode.Space)) {

                body.velocity += new Vector3(0, jumpHeight, 0);

            }

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
