using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;

public class AttackerDetails : MonoBehaviour
{
    [SerializeField] GameObject myAttacker;
    float difficulty;
    float health;
    [SerializeField] AnimationClip attackAnimation;
    void Start()
    {
        difficulty = PlayerPrefsController.GetDifficulty();
        health = myAttacker.GetComponent<Health>().health;
        GameObject[] statsArray = FindStats();
        SetStats(statsArray[0],statsArray[1]);
    }

    private void SetStats(GameObject attackerDamageStat, GameObject attackerHealthStat)
    {
        attackerDamageStat.GetComponent<TextMeshProUGUI>().text = attackAnimation.events[1].floatParameter.ToString();
        if (difficulty == 0)
        {
            attackerHealthStat.GetComponent<TextMeshProUGUI>().text = health.ToString();
        }
        else if (difficulty == 1)
        {
            health += 15;
            attackerHealthStat.GetComponent<TextMeshProUGUI>().text = health.ToString();
        }
        else if (difficulty == 2)
        {
            health += 30;
            attackerHealthStat.GetComponent<TextMeshProUGUI>().text = health.ToString();
        }
    }

    private GameObject[] FindStats()
    {
        GameObject[] statsArray = new GameObject[2]; 
        GameObject attackerDamageText = transform.GetChild(3).gameObject;
        GameObject attackerDamageStat = attackerDamageText.transform.GetChild(0).gameObject;
        GameObject attackerHealthText = transform.GetChild(4).gameObject;
        GameObject attackerHealthStat = attackerHealthText.transform.GetChild(0).gameObject;
        statsArray[0] = attackerDamageStat;
        statsArray[1] = attackerHealthStat;
        return statsArray;
    }

}
