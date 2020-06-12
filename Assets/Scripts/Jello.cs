using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jello : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otherCollision)
    {
        GameObject otherObject = otherCollision.gameObject;
        if (otherObject.GetComponent<Knight>())
        {
            gameObject.GetComponent<Attacker>().GoInvisible();
        }
        else if (!otherObject.GetComponent<Knight>() && otherObject.GetComponent<Defender>())
        {
            gameObject.GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
