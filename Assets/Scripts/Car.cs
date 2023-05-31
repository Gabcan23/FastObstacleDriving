using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Car : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject hud;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;

    private int steerValue;

    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
            highScoreText.text = $"High Score: {highScore}";
            hud.SetActive(false);
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    public void Steer(int value)
    {
        steerValue = value;

    }

    public void BackToMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void TryAgain(){
        if(MainMenu.energy>0)
        {
            MainMenu.energy--;
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }else{
            return;
        }
    }
}
