using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] public float defaultVolume = 0.1f;
    [SerializeField] public float defaultDifficulty = 2f;
    [SerializeField] GameObject firstTrack;
    [SerializeField] GameObject secondTrack;
    

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer!=null)
        {
            musicPlayer.GetComponent<AudioSource>().volume = volumeSlider.value; 
        }

        if(PlayerPrefsController.GetGameOver() == 1)
        {
            firstTrack.SetActive(true);
            secondTrack.SetActive(true);
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadStartScene();
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
