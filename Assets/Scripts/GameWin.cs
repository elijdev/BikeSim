using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject pauseButton;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
            pauseButton.SetActive(false);
        }
    }
}
