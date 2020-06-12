using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] public int stars = 100;
    TextMeshProUGUI starText;
    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnougStars(int amount)
    {
        if(stars>=amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   public void AddStars(int amount)
   {
        stars += amount;
        UpdateDisplay();
   }

    public void SpendingStars(int amount)
    {
            stars -= amount;
            UpdateDisplay();
    }
}
