using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    public const string HighScoreKey = "HighScore";
    private float score;
    private bool shouldCount = true;

    void Update()
    {
        if(!shouldCount){return;}

        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
        
    }

    public void StartTimer(){
        shouldCount = true;
    }

    public int EndTimer(){

        shouldCount = false;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);

    }

    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(score > currentHighScore)
        {
            if(Leaderboards.connectedToGooglePlay){
                Social.ReportScore(Mathf.FloorToInt(score),GPGSIds.leaderboard_drivepoints, LeaderboardUpdate);
            }

            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }

    }

    private void LeaderboardUpdate(bool success){
        if(success){Debug.Log("Updates Leaderboard");}
        else{Debug.Log("Failed to update leaderboard");}
    }
}
