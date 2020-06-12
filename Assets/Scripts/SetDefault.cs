using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefault : MonoBehaviour
{
    [SerializeField] Options gameOptions;
    float baseDifficulty;
    float baseVolume;
    void Start()
    {
        baseDifficulty = gameOptions.defaultDifficulty;
        baseVolume = gameOptions.defaultVolume;
        PlayerPrefsController.SetDifficulty(baseDifficulty);
        PlayerPrefsController.SetMasterVolume(baseVolume);
        PlayerPrefsController.SetGameOver(0);
    }
}
