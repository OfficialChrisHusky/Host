using System.Collections;
using UnityEngine;

public class AmmoPickup : MonoBehaviour, IPickup {

    [SerializeField] private Weapon weapon;
    [SerializeField] private int ammo;

    public void Pickup() {

        weapon.ammoInInventory += ammo;
        ammo = 0;

        Destroy(gameObject);

    }
}