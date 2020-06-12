using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] public int timeToWait = 3;
    [SerializeField] public float loseScreenLoadTime = 1.5f;
    [SerializeField] GameObject youLoseCanvas;
    [SerializeField] GameObject pauseMenuCanvas;

    int currentBuildIndex;
    bool isGamePaused = false;
    void Start()
    {
        if (FindObjectOfType<MusicPlayer>())
        {
            FindObjectOfType<MusicPlayer>().gameObject.GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
        }
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentBuildIndex == 0)
        {
          StartCoroutine(WaitAndLoad());
        } 
    }

    public void Update()
    {
        if(!isGamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
            FindObjectOfType<MusicPlayer>().gameObject.GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume() / 2;
        }
        else if(isGamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
            FindObjectOfType<MusicPlayer>().gameObject.GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
        }
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentBuildIndex + 1);
    }

    public void LoadYouLose()
    {
        youLoseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadStartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadSameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentBuildIndex);
    }

    public void LoadBeastsScene()
    {
        SceneManager.LoadScene(10);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
    }
}
