using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Weapon : MonoBehaviour {

    public string weaponName;
    public int damage;
    public float cooldown;
    public bool isEquiped;
    public bool isInInvetory;

    public GameObject weapon;

    public abstract void Attack();
    public abstract void PickUp();
    public abstract void Equip();

}
