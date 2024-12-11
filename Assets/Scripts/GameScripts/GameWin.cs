using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject pauseButton;
    [SerializeField] TextMeshProUGUI CoinText;
    [SerializeField] TextMeshProUGUI winTimeText;
    private string currentTimeKey = "LevelCurrentTime";
    private LevelTimer levelTimer;
    int totalCoins;

    private void Start()
    {
        // Find the LevelTimer in the scene (or assign it directly in the Inspector)
        levelTimer = FindObjectOfType<LevelTimer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (levelTimer != null)
            {
                levelTimer.CompleteLevel();
            }
            totalCoins = FindObjectOfType<CoinManager>().AddLevelReward();
            Time.timeScale = 0f;
            float currentTime = PlayerPrefs.GetFloat(currentTimeKey, 0f);
            winTimeText.text = "Time Finished: " + FormatTime(currentTime);
            CoinText.text = "Coins Earned: " + totalCoins;
            winPanel.SetActive(true);
            pauseButton.SetActive(false);
            
        }
    }

    private string FormatTime(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
