using System.Collections;
using UnityEngine;

public class Meelee : MonoBehaviour, Weapon {

    public int damage;

    public void Attack() {

        Debug.Log("Attack Meelee " + damage);

    }

}