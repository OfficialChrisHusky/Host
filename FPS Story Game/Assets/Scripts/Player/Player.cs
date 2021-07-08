using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;

    private void Awake() {

        if(instance == null) {

            instance = this;

        }
        
    }

    [Header("Scripts")]
    public PlayerMovement movement;
    public CameraLook cameraLook;
    public HealthSystem healthSystem;

    [Header("Player Variables")]
    public bool canMove;
    public bool canLook;

    public GameObject playerCamera;
    public GameObject playerBody;

    public void Die() {

        Debug.Log("ded");

        canMove = false;
        canLook = false;

    }

}
