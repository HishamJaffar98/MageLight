using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float health = 100f;
    [SerializeField] GameObject deathVFX;
    float difficulty;
    void Start()
    {
        difficulty = PlayerPrefsController.GetDifficulty();
        if(difficulty == 1f  && GetComponent<Attacker>())
        {
            health += 15f;
        }
        else if(difficulty == 2f && GetComponent<Attacker>())
        {
            health += 30f;
        }
    }
    void Update()
    {

    }

    public void DealDamage(float projectileDamage)
    {
        health -= projectileDamage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        TriggerVFX(); 
        Destroy(gameObject);
    }

    private void TriggerVFX()
    {
        var sparklez = Instantiate(deathVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(sparklez, 0.5f);
    }
}
