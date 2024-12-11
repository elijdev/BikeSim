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


    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Assembly()
    {
        SceneManager.LoadScene("Assembly");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        button.SetActive(false);
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        button.SetActive(true);
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
