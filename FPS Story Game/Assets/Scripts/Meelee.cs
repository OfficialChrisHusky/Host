using System.Collections;
using UnityEngine;

public class Meelee : Weapon {

    public string weaponName;
    public int id;
    public int damage;
    public float cooldown;
    public bool isEquiped;
    public bool isInInvetory;

    private float lastAttack;

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

        Debug.Log("Picked Up " + weaponName);

    }

}