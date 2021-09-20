using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    private bool isInArea;

    private void Update() {

        if(isInArea &&Input.GetKeyDown(KeyCode.E)) {

            Interact();

        }
        
    }

    public abstract void Interact();

    private void OnTriggerEnter(Collider other) {

        if(other.tag == "Player") {

            isInArea = true;

        }
        
    }

    private void OnTriggerExit(Collider other) {
        
        if(other.tag == "Player") {

            isInArea = false;

        }

    }

}
