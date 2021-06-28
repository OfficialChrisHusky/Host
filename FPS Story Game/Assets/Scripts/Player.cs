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
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private CameraLook cameraLook;

    [Header("Player Variables")]
    public bool canMove;
    public bool canLook;

    public GameObject playerCamera;
    public GameObject playerBody;


}
