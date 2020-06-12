using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batterfly : MonoBehaviour
{
    public bool isSlowed = false;
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherCollider.GetComponent<Defender>())
        {
            gameObject.GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
