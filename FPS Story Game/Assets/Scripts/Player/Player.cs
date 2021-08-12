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
    public PlayerLook cameraLook;
    public HealthSystem healthSystem;

    [Header("Player Variables")]
    public bool canMove;
    public bool canLook;

    public GameObject playerCamera;
    public GameObject playerBody;
    public GameObject weaponHolder;

    [Header("Weapons")]
    public Weapon currentWeapon;
    public List<Weapon> weapons = new List<Weapon>();

    public void Die() {

        //AudioManager.instance.Play("Player Death");

        canMove = false;
        canLook = false;

    }

    private void Update() {

        if (currentWeapon != null) {

            ChangeWeapon(Input.GetAxis("Mouse ScrollWheel"));

        }

        if (currentWeapon != null && Input.GetMouseButton(0)) {

            currentWeapon.Attack(playerCamera.transform);

        }

        if (currentWeapon != null && Input.GetKeyDown(KeyCode.R)) {

            StartCoroutine(currentWeapon.Reload());

        }

    }

    private void ChangeWeapon(float way) {

        if(way > 0) {

            for(int i = 1; currentWeapon.index + i < weapons.Count; i++) {

                if(weapons[currentWeapon.index + i].isInInventory) {

                    weapons[currentWeapon.index + i].Equip();

                }

            }

        } else if(way < 0) {

            for (int i = 1; currentWeapon.index - i >= 0; i++) {

                if (weapons[currentWeapon.index - i].isInInventory) {

                    weapons[currentWeapon.index - i].Equip();

                }

            }

        }

    }

    private void OnTriggerEnter(Collider other) {

        if(other.tag == "Pickup") {

            IPickup pickup = other.GetComponent<IPickup>();

            pickup.Pickup();

        }
        
    }

}
