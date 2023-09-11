using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;
    [SerializeField] private GameOverHandler gameOverHandler;

    [SerializeField] private GameObject defaultCar;
    [SerializeField] private GameObject secondCar;
    [SerializeField] private GameObject sedanCar;
    [SerializeField] private GameObject muscleCar;
    [SerializeField] private GameObject vanCar;
    [SerializeField] private GameObject policeCar;
    [SerializeField] private GameObject ambulanceCar;

    private int steerValue;

    void Start(){
        if(PlayerPrefs.GetInt(Store.secondCarUnlockedKey, 0) == 1 && PlayerPrefs.GetInt(Store.secondCarUseKey,0) == 1){
            defaultCar.gameObject.SetActive(false);
            secondCar.gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt(Store.sedanUnlockedKey, 0) == 1 && PlayerPrefs.GetInt(Store.sedanUseKey,0) == 1){
            defaultCar.gameObject.SetActive(false);
            sedanCar.gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt(Store.muscleCarUnlockedKey, 0) == 1 && PlayerPrefs.GetInt(Store.muscleCarUseKey,0) == 1){
            defaultCar.gameObject.SetActive(false);
            muscleCar.gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt(Store.vanUnlockedKey, 0) == 1 && PlayerPrefs.GetInt(Store.vanUseKey,0) == 1){
            defaultCar.gameObject.SetActive(false);
            vanCar.gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt(Store.policeCarUnlockedKey, 0) == 1 && PlayerPrefs.GetInt(Store.policeCarUseKey,0) == 1){
            defaultCar.gameObject.SetActive(false);
            policeCar.gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt(Store.ambulanceUnlockedKey, 0) == 1 && PlayerPrefs.GetInt(Store.ambulanceUseKey,0) == 1){
            defaultCar.gameObject.SetActive(false);
            ambulanceCar.gameObject.SetActive(true);
        }
    }

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
            gameOverHandler.EndGame();
        }

    }

    public void Steer(int value)
    {
        steerValue = value;

    }
}
