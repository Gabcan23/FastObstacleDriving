using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;

public class Leaderboards : MonoBehaviour
{
    public static bool connectedToGooglePlay;

    void Awake(){

        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

    }

    public void Start(){
        LogInToGooglePlay();
    }

    private void LogInToGooglePlay(){
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    private void ProcessAuthentication(SignInStatus status){
        if(status == SignInStatus.Success){
            connectedToGooglePlay = true;
        }
        else{
            connectedToGooglePlay = false;
        }
    }

    public void ShowLeaderboard(){
        if(!connectedToGooglePlay){LogInToGooglePlay();}
        Social.ShowLeaderboardUI();
    }

}
