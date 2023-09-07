using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private Button playAgainButton;

    [SerializeField] PauseMenu pauseMenu;

    private const string EnergyKey = "Energy";


    public void EndGame(){

        Time.timeScale = 0;

        pauseMenu.disablePauseMenu();
        int finalScore = scoreSystem.EndTimer();
        gameOverText.text=$"Your Score: {finalScore}";

        

        gameOverDisplay.gameObject.SetActive(true);

    }

    public void ContinueGame(){
        scoreSystem.StartTimer();
        
        Time.timeScale = 1;
        gameOverDisplay.gameObject.SetActive(false);
    }

    public void PlayAgain(){
        int energy1 = MainMenu.energy;
        if(energy1 < 1) { return; }

        if(energy1==0){
            playAgainButton.interactable = false;
        }

        energy1--;
        

        PlayerPrefs.SetInt(EnergyKey, energy1);
        Time.timeScale = 1;
        MainMenu.energy=energy1;
        SceneManager.LoadScene(1);

    }

    public void ReturnToMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
