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
        FindObjectOfType<AudioManager>().Stop("introBGM");
        FindObjectOfType<AudioManager>().Stop("victory");
        FindObjectOfType<AudioManager>().Play("gameBGM");
        FindObjectOfType<AudioManager>().Stop("moving");
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }

    public void Level2()
    {
        FindObjectOfType<AudioManager>().Stop("introBGM");
        FindObjectOfType<AudioManager>().Stop("victory");
        FindObjectOfType<AudioManager>().Play("gameBGM");
        FindObjectOfType<AudioManager>().Stop("moving");
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1f;
    }

    public void Level3()
    {
        FindObjectOfType<AudioManager>().Stop("introBGM");
        FindObjectOfType<AudioManager>().Stop("victory");
        FindObjectOfType<AudioManager>().Play("gameBGM");
        FindObjectOfType<AudioManager>().Stop("moving");
        SceneManager.LoadScene("Level 3");
        Time.timeScale = 1f;
    }

    public void Assembly()
    {
        FindObjectOfType<AudioManager>().Stop("introBGM");
        FindObjectOfType<AudioManager>().Stop("gameBGM");
        FindObjectOfType<AudioManager>().Stop("victory");
        FindObjectOfType<AudioManager>().Stop("moving");
        FindObjectOfType<AudioManager>().Play("assemblyBGM");
        SceneManager.LoadScene("Assembly");
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Stop("gameBGM");
        FindObjectOfType<AudioManager>().Stop("assemblyBGM");
        FindObjectOfType<AudioManager>().Stop("victory");
        FindObjectOfType<AudioManager>().Stop("moving");
        FindObjectOfType<AudioManager>().Play("introBGM");
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

    public void Click()
    {
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void ResetRecord()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
