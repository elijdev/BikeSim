using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bestTimeText;
    private float elapsedTime = 0f;
    private bool isRunning = false;

    private string levelKey;
    private string currentTimeKey;

    void Start()
    {
        string levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        levelKey = $"{levelName}_BestTime";
        currentTimeKey = $"{levelName}_CurrentTime";
        float bestTime = PlayerPrefs.GetFloat(levelKey, float.MaxValue);
        if (bestTime != float.MaxValue)
        {
            bestTimeText.text = "Time to Beat: " + FormatTime(bestTime);
        }
        else
        {
            bestTimeText.text = "Time to Beat: --:--:--";
        }

        timerText.text = "Current Time: " + FormatTime(0f);

        isRunning = true;
        UpdateTimerDisplay(0);
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay(elapsedTime);
        }
    }

    public void CompleteLevel()
    {
        isRunning = false;

        PlayerPrefs.SetFloat(currentTimeKey, elapsedTime);
        PlayerPrefs.Save();

        float bestTime = PlayerPrefs.GetFloat(levelKey, float.MaxValue);
        if (elapsedTime < bestTime)
        {
            PlayerPrefs.SetFloat(levelKey, elapsedTime);
            PlayerPrefs.Save();
            bestTimeText.text = "Time to Beat: " + FormatTime(elapsedTime);
            Debug.Log($"New Time to Beat: {FormatTime(elapsedTime)}");
        }
        else
        {
            Debug.Log($"Level Completed! Current Time: {FormatTime(elapsedTime)}, Best Time: {FormatTime(bestTime)}");
        }
    }

    private void UpdateTimerDisplay(float time)
    {
        timerText.text = "Time: " + FormatTime(time);
    }

    private string FormatTime(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
