using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("The level time in Seconds")]
    [SerializeField] float levelTime = 10;
    public bool levelTimerFinished;
    bool triggerLevelFinished = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerLevelFinished)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        levelTimerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(levelTimerFinished)
        {
            FindObjectOfType<LevelController>().StopSpawners();
            triggerLevelFinished = true;
        }
        
    }
}
