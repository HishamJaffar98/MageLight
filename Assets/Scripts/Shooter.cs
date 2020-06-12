using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    AttackSpawner myLaneSpawner;
    Animator animator;

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    void Start()
    {
        SetLaneSpawner();
        CreateProjectileParent();
        animator = GetComponent<Animator>();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        {
            if (!projectileParent)
            {
                projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
            }
        }
    }
    void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position,gun.transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

    private void SetLaneSpawner()
    {
        AttackSpawner[] spawners = FindObjectsOfType<AttackSpawner>();
        foreach(AttackSpawner attackSpawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(attackSpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(IsCloseEnough)
            {
                myLaneSpawner = attackSpawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if(!myLaneSpawner)
        {
            return false;
        }
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
