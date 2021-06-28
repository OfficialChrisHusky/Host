using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    
    [Header("Movement Variables")]
    public float moveSpeed = 10f;
    public float speedMultiplier = 2f;
    Vector3 velocity;

    [Header("Jump Variables")]
    public float gravityScale = 1f;
    public float jumpHeigth = 5f;
    private float gravity = -9.81f;

    [Header("Ground Check Variables")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.4f;
    public LayerMask whatIsGround;
    bool isGrounded;

    private void Start()
    {
        gravity = gravity * gravityScale;
    }
    void Update()
    {
        if (Player.instance.canMove)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, whatIsGround);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeigth * -2 * gravity);
            }



            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                move *= speedMultiplier;
            }

            playerController.Move(move * moveSpeed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            playerController.Move(velocity * Time.deltaTime);

        }
    }
}
