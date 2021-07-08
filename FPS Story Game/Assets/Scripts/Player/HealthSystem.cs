using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("Variables")] 
    public int maxHealth;
    [SerializeField] private int health;

    [Header("Components")] 
    public Image imageBar;

    private void Awake()
    {
        BarChanger();
    }

    private void BarChanger()
    {
        imageBar.fillAmount = health /(float) maxHealth;
    }

    public void Hit(int damageCount)
    {
        health -= damageCount;
        BarChanger();
        if (health <= 0)
        {
            health = 0;
            
            Player.instance.Die();
        }
    }

    public void Heal(int healCount)
    {
        health += healCount;
        BarChanger();
        if (health > maxHealth)
        {
            health = maxHealth;
            //Debug.Log("!Max Health:" + health);
        }
    }
    
    //hps: 1 Health Per Second
    public IEnumerator RegenerationHealth(float hps)
    {
        while (true)
        {
            health++;
            BarChanger();
            if (health > maxHealth)
            {
                health = maxHealth;
                //Debug.Log("!Max Health:" + health);
                yield break;
            }
            yield return new WaitForSeconds(hps);
        }
    }
}
