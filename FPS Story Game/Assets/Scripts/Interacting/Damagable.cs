using System.Collections;
using UnityEngine;

public abstract class Damagable : MonoBehaviour {

    [SerializeField] private int health;
    [SerializeField] private AudioSource S_hit;
    [SerializeField] private AudioSource S_break;

    [SerializeField] private GameObject empty;

    public void Hit(int amount) {

        health -= amount;

        if(health <= 0) {

            AudioSource src = Instantiate(empty, transform.position, transform.rotation).AddComponent<AudioSource>();

            src.clip = S_break.clip;

            src.volume = S_break.volume;
            src.pitch = S_break.pitch;
            src.spatialBlend = S_break.spatialBlend;

            src.playOnAwake = S_break.playOnAwake;

            src.Play();

            Destroy(gameObject);
            Destroy(src.gameObject, 1);

            return;
            

        }

        S_hit.Play();

    }

}