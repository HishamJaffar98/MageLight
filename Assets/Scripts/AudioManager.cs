using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip firstSong;
    [SerializeField] AudioClip secondSong;

    MusicPlayer musicPlayer;
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    public void SwitchToFirstTrack()
    {
        if(musicPlayer.GetComponent<AudioSource>().clip == firstSong)
        {
            return;
        }
        else
        {
            musicPlayer.PlayMusic(firstSong);
        }
    }

    public void SwitchToSecondTrack()
    {
        if (musicPlayer.GetComponent<AudioSource>().clip == secondSong)
        {
            return;
        }
        else
        {
            musicPlayer.PlayMusic(secondSong);
        }
    }
    void Update()
    {
        
    }
}
