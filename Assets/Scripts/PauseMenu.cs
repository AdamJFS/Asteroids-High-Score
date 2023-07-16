using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    [SerializeField] GameObject pauseMenu;

    public Button buttonShoot;
    public Button pauseButtonPlay;
    public Button thurstButton;

    public void Pause()
    {
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        buttonShoot.enabled = false;
        pauseButtonPlay.enabled = false;
        thurstButton.enabled = false;
        
    }

    public void Resume()
    {
        
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        buttonShoot.enabled = true;
        pauseButtonPlay.enabled = true;
        thurstButton.enabled = true;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
}
