using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    Fireball fireball;
    Magicball magicball;
    Iceball iceball;
    Timeball timeball;

    public void SetProjectileGameObjects()
    {
        if(gameObject.GetComponent<Fireball>())
        {
            fireball = gameObject.GetComponent<Fireball>();
        }
        else if(gameObject.GetComponent<Magicball>())
        {
            magicball = gameObject.GetComponent<Magicball>();
        }
        else if(gameObject.GetComponent<Iceball>())
        {
            iceball = gameObject.GetComponent<Iceball>();
        }
        else if(gameObject.GetComponent<Timeball>())
        {
            timeball = gameObject.GetComponent<Timeball>();
        }
        else
        {
            return;
        }
    }

    public float GetProjectileDamage()
    {
        if(fireball)
        {
            return fireball.damageDone;
        }
        else if(iceball)
        {
            return iceball.damageDone;
        }
        else if(magicball)
        {
            return magicball.damageDone;
        }
        else
        {
            return timeball.damageDone;
        }

    }
}
