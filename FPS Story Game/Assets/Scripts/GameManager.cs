using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private void Awake() {

        if(instance == null) {

            instance = this;

        }
        
    }

    public Transform playerBody;

    private void Update() {

        if(Input.GetKeyDown(KeyCode.F6)) {

            SaveGame();

        } else if(Input.GetKeyDown(KeyCode.F7)) {

            LoadSave();

        } else if(Input.GetKeyDown(KeyCode.H)) {

            Player.instance.healthSystem.Hit(10);

        } else if(Input.GetKeyDown(KeyCode.G)) {

            Player.instance.healthSystem.Heal(15);

        }
        
    }

    public void SaveGame() {

        SaveSystem.Save(Player.instance);

    }

    public void LoadSave() {

        Save save = SaveSystem.Load();

        Vector3 position = new Vector3(save.position[0], save.position[1], save.position[2]);

        Quaternion camRotation = new Quaternion(save.rotation[0], 0, 0, save.rotation[1]);
        Quaternion bodyRotation = new Quaternion(0, save.rotation[2], 0, save.rotation[3]);

        Player.instance.gameObject.GetComponent<CharacterController>().enabled = false;

        Player.instance.transform.position = position;

        Player.instance.playerCamera.transform.rotation = camRotation;
        Player.instance.transform.rotation = bodyRotation;

        Player.instance.gameObject.GetComponent<CharacterController>().enabled = true;

    }
    
}