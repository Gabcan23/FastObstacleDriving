using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] carPrefabs;

    public static Vector3 spawnPoint = new Vector3(0,0,9.5f);
    int characterIndex;

    public CinemachineVirtualCamera VCam;
    public GameOverHandler gameOverHandler;

    private void Awake(){
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject Car = Instantiate(carPrefabs[characterIndex], spawnPoint, Quaternion.identity);
        VCam.m_Follow = Car.transform;
        gameOverHandler.player = Car;
    }
}
