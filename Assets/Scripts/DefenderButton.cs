using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] public Defender myDefender;
    [SerializeField] GameObject defenderStats;
    [SerializeField] GameObject defenderProjectile;
    DefenderButton[] defenderButtonArray;

    void Start()
    {
        SetPlayerStats();
        TextMeshProUGUI defenderCost = GetComponentInChildren<TextMeshProUGUI>();
        if (!defenderCost)
        {
            Debug.LogError("Cost text component not found. Please add.");
        }
        else
        {
            defenderCost.text = myDefender.GetStarCost().ToString();
        }
        defenderButtonArray = new DefenderButton[6];
    }

    private void SetPlayerStats()
    {

        GameObject healthStat = defenderStats.transform.GetChild(3).transform.GetChild(0).gameObject;
        GameObject costStat = defenderStats.transform.GetChild(4).transform.GetChild(0).gameObject;

        if (defenderStats.gameObject.name == "Alchemist Stats")
        {
            GameObject alchemistLimitStat = defenderStats.transform.GetChild(5).transform.GetChild(0).gameObject;
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 5:
                    alchemistLimitStat.GetComponent<TextMeshProUGUI>().text = 5.ToString();
                    break;
                case 6:
                    alchemistLimitStat.GetComponent<TextMeshProUGUI>().text = 6.ToString();
                    break;
                case 7:
                    alchemistLimitStat.GetComponent<TextMeshProUGUI>().text = 6.ToString();
                    break;
                default:
                    alchemistLimitStat.GetComponent<TextMeshProUGUI>().text = 4.ToString();
                    break;
            }
        }
        else
        {
            GameObject defenderDamageStatParent = defenderStats.transform.GetChild(5).gameObject;
            GameObject damageStat = defenderDamageStatParent.transform.GetChild(0).gameObject;

            healthStat.GetComponent<TextMeshProUGUI>().text = myDefender.GetHealth().ToString();
            costStat.GetComponent<TextMeshProUGUI>().text = myDefender.GetStarCost().ToString();
            if (defenderProjectile)
            {
                defenderProjectile.GetComponent<ProjectileDamage>().SetProjectileGameObjects();
                damageStat.GetComponent<TextMeshProUGUI>().text = defenderProjectile.GetComponent<ProjectileDamage>().GetProjectileDamage().ToString();
            }
            else
            {
                return;
            }
        }
    }

    void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        int counter = 0;
        for(int index = 0; index<buttons.Length; index++)
        {
            if(buttons[index].gameObject.GetComponent<DefenderButton>().isActiveAndEnabled)
            {
                defenderButtonArray[counter] = buttons[index];
                counter++;
            }
            else if(buttons[index].gameObject.GetComponent<DefenderButton>().enabled == false)
            {
                continue;
            }
        }

        foreach(DefenderButton button in defenderButtonArray)
        {
            if(button)
            {
                button.GetComponent<SpriteRenderer>().color = new Color32(79, 79, 79, 255);
            }   
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().DefenderToBeSelected(myDefender);
    }

    void OnMouseEnter()
    {
        defenderStats.SetActive(true);
    }

    void OnMouseExit()
    {
        defenderStats.SetActive(false);
    }
}
