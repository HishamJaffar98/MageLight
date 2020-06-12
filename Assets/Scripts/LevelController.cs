using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    [Tooltip("Just here for debugging purposes")]
    [SerializeField] int attackersOnScreen = 0;
    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] float timeToLoadNextLevel = 1f;

    GameTimer gameTimer;
    int currentBuildIndex;
    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
    }

    void Update()
    {
        attackersOnScreen = FindObjectsOfType<Attacker>().Length;
        if (gameTimer.levelTimerFinished == true && attackersOnScreen <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        levelCompleteCanvas.SetActive(true);
        if(FindObjectOfType<MusicPlayer>())
        {
            FindObjectOfType<MusicPlayer>().gameObject.GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume() / 2;
        }
        yield return new WaitForSeconds(timeToLoadNextLevel);
        SceneManager.LoadScene(currentBuildIndex + 1);
        
    }
    public void StopSpawners()
    {
        AttackSpawner[] spawnerArray = FindObjectsOfType<AttackSpawner>();
        foreach(AttackSpawner spawner in spawnerArray )
        {
            spawner.StopSpawning();
        }
    }
}
