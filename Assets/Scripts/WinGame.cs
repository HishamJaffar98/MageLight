using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] AudioClip secondSong;
    void Start()
    {
        PlayerPrefsController.SetGameOver(1);
        if (FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().clip == secondSong)
        {
            return;
        }
        else
        {
            FindObjectOfType<MusicPlayer>().PlayMusic(secondSong);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
