using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public bool isPaused;
    private OriginalStatsPlayer originalStats;
    public int kills;

   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Main")
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void GameOver()
    {
        originalStats = FindObjectOfType<OriginalStatsPlayer>();
        originalStats.ResetStats();
       // SceneManager.LoadScene("GameOver");
    }

    public void PlayGame()
    {

        SceneManager.LoadScene("Main");
    }

    private void OnApplicationQuit()
    {
        originalStats = FindObjectOfType<OriginalStatsPlayer>();
        originalStats.ResetStats();
    }
}