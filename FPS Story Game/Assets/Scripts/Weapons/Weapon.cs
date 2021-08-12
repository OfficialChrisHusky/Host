using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [Header("Main")]
    [SerializeField] private string weaponName;
    [SerializeField] private bool meelee;

    [Header("Ammo And Reloading")]
    public int maxAmmo;
    public int ammo;
    public int ammoInInventory;

    [SerializeField] private float reloadTime;

    [Header("Fire variables")]
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float impactForce;
    [SerializeField] private float fireRate;

    private float nextFire;

    [Header("Sounds")]
    [SerializeField] private string S_shot;
    [SerializeField] private string S_empty;
    [SerializeField] private string S_reload;

    public bool isInInventory;
    public int index;

    public void Equip() {

        if(Player.instance.currentWeapon != null) {

            Destroy(Player.instance.weaponHolder.transform.GetChild(0).gameObject);

        }

        Instantiate(gameObject, Player.instance.weaponHolder.transform).GetComponent<Weapon>();

        Player.instance.currentWeapon = this;

        isInInventory = true;

        nextFire = 0;

    }

    public void Attack(Transform cam) {

        if (Time.time >= nextFire) {

            nextFire = Time.time + 1f / fireRate;

            if (ammo > 0) {

                AudioManager.instance.Play(S_shot);

                RaycastHit hit;

                if (Physics.Raycast(cam.position, cam.forward, out hit, range)) {

                    Damagable damagable = hit.transform.GetComponent<Damagable>();

                    if (damagable != null) {

                        damagable.Hit(damage);

                    }

                    if (hit.rigidbody != null) {

                        hit.rigidbody.AddForce(-hit.normal * impactForce);

                    }

                }

                if (!meelee) {

                    ammo--;

                }

            } else {

                AudioManager.instance.Play(S_empty);

            }

        }

    }

    public IEnumerator Reload() {

        if (!meelee) {

            if (ammoInInventory > 0) {

                AudioManager.instance.Play(S_reload);

                yield return new WaitForSeconds(reloadTime);

                if (ammoInInventory >= maxAmmo) {

                    ammo = maxAmmo;
                    ammoInInventory -= maxAmmo;

                } else {

                    ammo = ammoInInventory;
                    ammoInInventory = 0;

                }

            }

        }

        yield return null;

    }

}
