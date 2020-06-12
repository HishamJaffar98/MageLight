using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    const string DEFENDER_PARENT_NAME = "Defenders";
    GameObject defenderParent;
    [SerializeField] AudioClip placeDefenderAudio;

    private void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        if(defender.tag == "Alchemist" && GameObject.FindGameObjectsWithTag("Alchemist").Length == 4 && SceneManager.GetActiveScene().buildIndex < 5)
        {
            return; 
        }
        else if(defender.tag == "Alchemist" && GameObject.FindGameObjectsWithTag("Alchemist").Length == 5 && SceneManager.GetActiveScene().buildIndex == 5)
        {
            return;
        }
        else if(defender.tag == "Alchemist" && GameObject.FindGameObjectsWithTag("Alchemist").Length == 6 && SceneManager.GetActiveScene().buildIndex > 5)
        {
            return;
        }
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }
    public void DefenderToBeSelected(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if(StarDisplay.HaveEnougStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendingStars(defenderCost);
        }
    }
    private void SpawnDefender(Vector2 clickedPosition)
    {
        Defender newDefender = Instantiate(defender, clickedPosition, Quaternion.identity) as Defender;
        GetComponent<AudioSource>().PlayOneShot(placeDefenderAudio);
        newDefender.transform.parent = defenderParent.transform;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        int newX = Mathf.RoundToInt(rawWorldPos.x);
        int newY = Mathf.RoundToInt(rawWorldPos.y);
        Vector2 newWorldPos = new Vector2(newX, newY);
        return newWorldPos;
    }
}
