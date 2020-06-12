using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasePointsDisplay : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = FindObjectOfType<PlayerBase>().basePoints.ToString();
    }

}
