using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour //shar
{
    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver,
    }

    //stores current state of game
    public GameState currentState;
    //stores previous state of game
    public GameState previousState;

    [Header("Screens")]
    public GameObject pauseScreen;
    //public GameObject gameOverScreen;

    [Header("Stopwatch")]
    public float timeLimit;
    float stopwatchTime;
    public TMP_Text stopwatchDisplay; 

    //checks for gameover
    public bool isGameOver = false;

    void Awake()
    {
        DisableScreens();
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.Gameplay:
                CheckForPauseAndResume();
                UpdateStopwatch();
                break;

            case GameState.Paused:
                CheckForPauseAndResume();
                break;

            case GameState.GameOver:
                if (!isGameOver)
                {
                    isGameOver = true;
                    Time.timeScale = 0f; //stops game
                    GameObject.FindObjectOfType<PlayerStats>().Kill();
                    Debug.Log("Game over");
                }
                break;

            default:
                Debug.LogWarning("State does not exist");
                break;
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if (currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f; //stops game
            pauseScreen.SetActive(true);
            Debug.Log("Game is paused");
        }
    }

    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f; //resumes game
            pauseScreen.SetActive(false);
            Debug.Log("Game is resumed");
        }
    }

    void CheckForPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void DisableScreens()
    {
        pauseScreen.SetActive(false);
        //gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
        //gameOverScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application has been exited");
    }

    void UpdateStopwatch()
    {
        stopwatchTime += Time.deltaTime;

        UpdateStopwatchDisplay();

        if (stopwatchTime >= timeLimit)
        {
            GameOver();
        }
    }

    void UpdateStopwatchDisplay()
    {
        //calculate number of minutes and seconds that have elapsed
        int mins = Mathf.FloorToInt(stopwatchTime / 60);
        int secs = Mathf.FloorToInt(stopwatchTime % 60); 

        //updates stopwatch time to display elapsed time
        stopwatchDisplay.text = string.Format("{0:00}:{1:00}", mins, secs);
    }
}
