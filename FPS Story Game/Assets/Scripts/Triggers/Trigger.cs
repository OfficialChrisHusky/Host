using UnityEngine;

public class Trigger : MonoBehaviour {

    public virtual void Enter(Collider other) {

        Debug.Log(other.name + " has entered trigger " + gameObject.name);

    }
    public virtual void Stay(Collider other) {

        Debug.Log(other.name + " is in trigger " + gameObject.name);

    }
    public virtual void Exit(Collider other) {

        Debug.Log(other.name + " has exited trigger " + gameObject.name);

    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Player") {

            Enter(other);

        }

    }

    private void OnTriggerStay(Collider other) {
        
        if(other.tag == "Player") {

            Stay(other);

        }

    }

    private void OnTriggerExit(Collider other) {
        
        if(other.tag == "Player") {

            Exit(other);

        }

    }

}