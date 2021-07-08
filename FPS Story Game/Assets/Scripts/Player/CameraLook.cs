using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform player;

    private float x;
    private float y;

    private void Start() {

        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update() {

        if(Player.instance.canLook) {

            x += -Input.GetAxis("Mouse Y") * mouseSensitivity * 10 * Time.deltaTime;
            y +=  Input.GetAxis("Mouse X") * mouseSensitivity * 10 * Time.deltaTime;

            x = Mathf.Clamp(x, -90f, 90f);

        }

    }

    private void FixedUpdate() {

        transform.localRotation = Quaternion.Euler(x, 0.0f, 0.0f);
        player.rotation = Quaternion.Euler(0.0f, y, 0.0f);
        
    }

}
