using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButtonMenu()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}//class
