using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {

    public float mouseSensitivity;
    public bool canLook;

    private float x;
    private float y;

    public Transform body;

    private void Start() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    private void Update() {

        if(canLook) {

            x += -Input.GetAxis("Mouse Y") * mouseSensitivity;
            y += Input.GetAxis("Mouse X") * mouseSensitivity;

            x = Mathf.Clamp(x, -90, 90);

        }
        
    }

    private void FixedUpdate() {

        transform.localRotation = Quaternion.Euler(x, 0, 0);
        body.rotation = Quaternion.Euler(0, y, 0);
        
    }
    
}
