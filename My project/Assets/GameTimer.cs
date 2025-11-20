using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startingTime = 180f;   // 3 minutes
    private float timeRemaining;
    private bool timerIsRunning = false;

    [Header("UI References")]
    public TextMeshProUGUI timerText;   // HUD timer text
    public GameObject startMenuUI;      // Start menu canvas

    void Start()
    {
        // Initialize time
        timeRemaining = startingTime;

        // Show the full time on screen before starting
        if (timerText != null)
        {
            UpdateTimerDisplay(timeRemaining);
        }

        // Show start menu and pause game time
        if (startMenuUI != null)
        {
            startMenuUI.SetActive(true);
        }

        // Freeze everything until player hits Start
        Time.timeScale = 0f;
        timerIsRunning = false;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;

                if (timeRemaining < 0f)
                    timeRemaining = 0f;

                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0f;
                timerIsRunning = false;
                QuitGame();
            }
        }
    }

    public void StartGame()
    {
        // Hide start menu
        if (startMenuUI != null)
        {
            startMenuUI.SetActive(false);
        }

        // Start game + timer
        Time.timeScale = 1f;
        timerIsRunning = true;
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        if (timeToDisplay < 0f)
            timeToDisplay = 0f;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60f);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60f);

        if (timerText != null)
        {
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // stop Play mode in Editor
        #else
        Application.Quit();  // quit in build
        #endif
    }
}
