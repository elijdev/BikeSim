using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI Level1TimerText;
    public TextMeshProUGUI Level2TimerText;
    public TextMeshProUGUI Level3TimerText;

    private string levelKey;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            levelKey = $"Level {i}_BestTime";
            float bestTime = PlayerPrefs.GetFloat(levelKey, float.MaxValue);

            if (i == 1)
            {
                Level1TimerText.text = bestTime != float.MaxValue
                    ? "Record TIme: " + FormatTime(bestTime)
                    : "Record TIme: --:--:--";
            }
            else if (i == 2)
            {
                Level2TimerText.text = bestTime != float.MaxValue
                    ? "Record TIme: " + FormatTime(bestTime)
                    : "Record TIme: --:--:--";
            }
            else if (i == 3)
            {
                Level3TimerText.text = bestTime != float.MaxValue
                    ? "Record TIme: " + FormatTime(bestTime)
                    : "Record TIme: --:--:--";
            }
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