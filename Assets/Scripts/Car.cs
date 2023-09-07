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

    private int steerValue;

    void Start(){
        if(PlayerPrefs.GetInt(Store.secondCarUnlockedKey, 0) == 1){
            defaultCar.gameObject.SetActive(false);
            secondCar.gameObject.SetActive(true);
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
