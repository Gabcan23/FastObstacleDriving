using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject pauseMenu;

    public GameObject hud;

    public void Resume(){
        pauseMenu.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Pause(){
        pauseMenu.SetActive(true);
        hud.SetActive(false);
        Time.timeScale = 0f;

    }

    public void mainMenu(){
        MainMenu.energy++;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
