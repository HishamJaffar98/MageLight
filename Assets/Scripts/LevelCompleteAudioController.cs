using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteAudioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
