using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject button;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPanel.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Assembly()
    {
        SceneManager.LoadScene("Assembly");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        button.SetActive(false);
        menuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        button.SetActive(true);
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
