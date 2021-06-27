using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public Weapon weapon;

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player") {

            weapon.PickUp();

        }
        
    }

}