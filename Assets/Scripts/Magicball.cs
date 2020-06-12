using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicball : MonoBehaviour
{
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] public float damageDone = 50f;
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
        var batterfly = otherCollision.GetComponent<Batterfly>();
        if (health && attacker && !batterfly)
        {
            health.DealDamage(damageDone);
            Destroy(gameObject);
        }
        else if (health && attacker && batterfly && batterfly.isSlowed == false)
        {
            return;
        }
        else if (health && attacker && batterfly && batterfly.isSlowed == true)
        {
            health.DealDamage(damageDone);
            Destroy(gameObject);
        }
    }
}
