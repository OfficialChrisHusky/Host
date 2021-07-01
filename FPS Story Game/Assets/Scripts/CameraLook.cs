using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform player;

    float xRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
            float mouseX = Input.GetAxis("Mouse X") * (mouseSensitivity * 10) * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity * 10) * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
    }
}
