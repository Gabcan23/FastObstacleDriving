using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private Button playButton;
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] private IOSNotificationHandler iosNotificationHandler;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;

    public static int energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        OnApplicationFocus(true);

    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if(!hasFocus) { return; }

        CancelInvoke();

        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);


        highScoreText.text = $"High Score: {highScore}";

        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if(energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if(energyReadyString == string.Empty) { return; }

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if(DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
            else
            {
                playButton.interactable = false;
                Invoke(nameof(EnergyRecharged), (energyReady - DateTime.Now).Seconds);

            }
        }

        energyText.text = $"{energy}";

    }

    public void EnergyRecharged()
    {
        playButton.interactable = true;
        energy = maxEnergy;
        
        PlayerPrefs.SetInt(EnergyKey, energy);
        energyText.text = $"{energy}";

    }

    public void SetMainVolume(float volume)
    {
        audioMixer.SetFloat("MainVolume",volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music Volume",volume);
    }

    public void Play()
    {
        if(energy < 1) { return; }

        energy--;
        

        PlayerPrefs.SetInt(EnergyKey, energy);

        if(energy == 0)
        {

        DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
        PlayerPrefs.SetString(EnergyReadyKey,  energyReady.ToString());
#if UNITY_ANDROID
        androidNotificationHandler.ScheduleNotification(energyReady);
#elif UNITY_IOS
        iosNotificationHandler.ScheduleNotification(energyRechargeDuration);
#endif
        }


        SceneManager.LoadScene(1);


    }


}
