using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DefenderShower : MonoBehaviour
{
    [SerializeField] GameObject knightButton;
    [SerializeField] GameObject fireWizardButton;
    [SerializeField] GameObject iceWizardButton;
    [SerializeField] GameObject timeArcherButton;

    void Start()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        switch(buildIndex)
        {
            case 2:
                BlackOutDefenderButton(knightButton);
                BlackOutDefenderButton(fireWizardButton);
                BlackOutDefenderButton(iceWizardButton);
                BlackOutDefenderButton(timeArcherButton);
                break;
            case 3:
                BlackOutDefenderButton(fireWizardButton);
                BlackOutDefenderButton(iceWizardButton);
                BlackOutDefenderButton(timeArcherButton);
                break;
            case 4:
                BlackOutDefenderButton(iceWizardButton);
                BlackOutDefenderButton(timeArcherButton);
                break;
            case 5:
                BlackOutDefenderButton(timeArcherButton);
                break;
            default:
                break;
        }
    }

    private void BlackOutDefenderButton(GameObject defenderButton)
    {
        defenderButton.GetComponent<SpriteRenderer>().color = Color.black;
        defenderButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        defenderButton.GetComponentInChildren<TextMeshProUGUI>().text = "000";
        defenderButton.GetComponent<BoxCollider2D>().enabled = false;
        defenderButton.GetComponent<DefenderButton>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
