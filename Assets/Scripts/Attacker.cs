using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [SerializeField] int timesAttacked = 0;
    [SerializeField] int effectShot;
    [SerializeField] float currentSpeed = 1f;

    GameObject currentTarget;
    float defenderAnimatorSpeed = 0.5f;
    Color damageColor = new Color(0.1509434f, 0.139949f, 0.1374155f);
    Color burnColor = new Color(1f, 0.2346973f, 0.0235849f);
    Color freezeColor = new Color(0f, 0.3656104f, 1f);

    void Start()
    {
        effectShot = UnityEngine.Random.Range(0, 7);
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public float GetMovementSpeed()
    {
        return currentSpeed;
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
        if(!currentTarget)
        {
            return;
        }
    }

    public void GoInvisible()
    {
        GetComponent<Animator>().SetTrigger("isInvisible");
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget && !currentTarget.GetComponentInChildren<SpriteRenderer>())
        {
            return;
        }
        damage = SetStatusEffect(damage);
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
        StartCoroutine(WaitBeforeTurningNormalColor());
    }
    private float SetStatusEffect(float damage)
    {
        timesAttacked++;
        if (timesAttacked >= effectShot && gameObject.GetComponent<Lizard>())
        {
            damageColor = burnColor;
            damage = damage + 30;
        }
        else if (timesAttacked >= effectShot && gameObject.GetComponent<Freezy>())
        {
            damageColor = freezeColor;
            damage = damage + 15;
            currentTarget.GetComponent<Animator>().speed = defenderAnimatorSpeed;
        }
        SetHitFeedback(damageColor);
        return damage;
    }

    private void SetHitFeedback(Color newColor)
    {
        currentTarget.GetComponentInChildren<SpriteRenderer>().color = newColor;
    }

    IEnumerator WaitBeforeTurningNormalColor()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        if(currentTarget.GetComponentInChildren<SpriteRenderer>())
        {
            currentTarget.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
        else if(!currentTarget)
        {
            DoNothing();
        }
        
    }

    private void DoNothing()
    {
        return;
    }

    void OnDestroy()
    {
        if (currentTarget)
        {
            currentTarget.GetComponent<Animator>().speed = 1f;
            currentTarget.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
        else
        {
            return;
        }

    }



 
}
