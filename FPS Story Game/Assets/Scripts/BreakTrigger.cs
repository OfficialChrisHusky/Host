using System.Collections;
using UnityEngine;

public class BreakTrigger : MonoBehaviour {

    public float Time;

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player") {

            Destroy(gameObject, Time);

        }
        
    }

}