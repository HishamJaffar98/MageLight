using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.gameObject.GetComponent<Magicball>() || otherCollider.gameObject.GetComponent<Fireball>() || otherCollider.gameObject.GetComponent<Iceball>() || otherCollider.gameObject.GetComponent<Timeball>())
        {
            Destroy(otherCollider.gameObject);
        }
        else
        {
            return;
        }
        
    }
    
}
