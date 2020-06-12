﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty" ;
    const string GAME_OVER = "gameOver";

    const float MIN_VOLUME = 0f;
    public const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;
    public static void SetMasterVolume(float volume)
    {
        if(volume>=MIN_VOLUME && volume<=MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master Volume is out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty)
    {
        if(difficulty>=MIN_DIFFICULTY && difficulty<=MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficult is out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void SetGameOver(int gameOver)
    {
        PlayerPrefs.SetInt(GAME_OVER, gameOver);
    }

    public static int GetGameOver()
    {
        return PlayerPrefs.GetInt(GAME_OVER);
    }


}
