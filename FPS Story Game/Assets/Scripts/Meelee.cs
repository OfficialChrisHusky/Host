using System.Collections;
using UnityEngine;

public class Meelee : Weapon {

    private float lastAttack;

    private void Start() {

        isInInvetory = true;
        isEquiped = true;

    }

    private void Update() {

        if(Input.GetMouseButtonDown(0) && lastAttack >= cooldown && isEquiped) {

            Attack();

            lastAttack = 0;

        }

        lastAttack += Time.deltaTime;
        
    }

    public override void Attack() {

        Debug.Log("Attack Meelee " + damage);

    }

    public override void PickUp() {

        if(!isInInvetory) {

            Equip();

        }

    }

    public override void Equip() {

        Instantiate(weapon, CameraLook.instance.equipPlaceholder);
        
    }

}