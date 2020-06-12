using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] float damageDone = 50f;
    

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D otherCollision)
    {
        var health = otherCollision.GetComponent<Health>();
        var attacker = otherCollision.GetComponent<Attacker>();
        if(health && attacker)
        {
            health.DealDamage(damageDone);
            Destroy(gameObject);
        }
        
    }
}
