using System.Collections;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour {

    public GameObject cutsceneCamera;

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player") {

            cutsceneCamera.transform.position = Player.instance.playerCamera.transform.position;
            cutsceneCamera.transform.rotation = Player.instance.playerCamera.transform.rotation;

            Player.instance.playerBody.SetActive(false);
            cutsceneCamera.SetActive(true);

        }
        
    }

}