using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] public int basePoints = 5;

   IEnumerator OnTriggerEnter2D(Collider2D otherCollider)
    {
        basePoints--;
        GameObject otherObject = otherCollider.gameObject;
        Destroy(otherObject);
        if(basePoints <= 0)
        {
            basePoints = 0;
            yield return new WaitForSeconds(FindObjectOfType<LevelLoader>().loseScreenLoadTime);
            FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }
}
