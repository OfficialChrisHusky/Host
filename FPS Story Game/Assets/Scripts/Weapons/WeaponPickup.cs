using System.Collections;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, IPickup {

    [SerializeField]
    private Weapon weapon;

    public void Pickup() {

        weapon.Equip();

        Destroy(gameObject);

    }
}