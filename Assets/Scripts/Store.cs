using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class Store : MonoBehaviour
{
    private const string secondCarId = "com.rofungames.cdriving.secondcar";
    private const string sedanId = "com.rofungames.cdriving.sedan";
    private const string muscleCarId = "com.rofungames.cdriving.musclecar";
    private const string vanId = "com.rofungames.cdriving.van";
    private const string policeCarId = "com.rofungames.cdriving.policecar";
    private const string ambulanceId = "com.rofungames.cdriving.ambulance";

    public const string secondCarUnlockedKey = "SecondCarUnlocked";
    public const string sedanUnlockedKey = "SedanUnlocked";
    public const string muscleCarUnlockedKey = "MuscleCarUnlocked";
    public const string vanUnlockedKey = "VanUnlocked";
    public const string policeCarUnlockedKey = "PoliceCarUnlocked";
    public const string ambulanceUnlockedKey = "AmbulanceUnlocked";
    public const string secondCarUseKey = "SecondCarUse";
    public const string sedanUseKey = "SedanUse";
    public const string muscleCarUseKey = "MuscleCarUse";
    public const string vanUseKey = "VanUse";
    public const string policeCarUseKey = "PoliceCarUse";
    public const string ambulanceUseKey = "ambulanceUse";


    [SerializeField] private GameObject buySecondCarButton;
    [SerializeField] private GameObject selectSecondCarButton;
    [SerializeField] private GameObject buySedanButton;
    [SerializeField] private GameObject selectSedanButton;
    [SerializeField] private GameObject buyMuscleCarButton;
    [SerializeField] private GameObject selectMuscleCarButton;
    [SerializeField] private GameObject buyVanButton;
    [SerializeField] private GameObject selectVanButton;
    [SerializeField] private GameObject buyPoliceCarButton;
    [SerializeField] private GameObject selectPoliceCarButton;
    [SerializeField] private GameObject buyAmbulanceButton;
    [SerializeField] private GameObject selectAmbulanceButton;

    public void CheckIfBought(){
        if(PlayerPrefs.GetInt(secondCarUnlockedKey, 0) == 1){
            buySecondCarButton.gameObject.SetActive(false);
            selectSecondCarButton.gameObject.SetActive(true);
        }else{
            buySecondCarButton.gameObject.SetActive(true);
            selectSecondCarButton.gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt(sedanUnlockedKey, 0) == 1){
            buySedanButton.gameObject.SetActive(false);
            selectSedanButton.gameObject.SetActive(true);
        }else{
            buySedanButton.gameObject.SetActive(true);
            selectSedanButton.gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt(muscleCarUnlockedKey, 0) == 1){
            buyMuscleCarButton.gameObject.SetActive(false);
            selectMuscleCarButton.gameObject.SetActive(true);
        }else{
            buyMuscleCarButton.gameObject.SetActive(true);
            selectMuscleCarButton.gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt(vanUnlockedKey, 0) == 1){
            buyVanButton.gameObject.SetActive(false);
            selectVanButton.gameObject.SetActive(true);
        }else{
            buyVanButton.gameObject.SetActive(true);
            selectVanButton.gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt(policeCarUnlockedKey, 0) == 1){
            buyPoliceCarButton.gameObject.SetActive(false);
            selectPoliceCarButton.gameObject.SetActive(true);
        }else{
            buyPoliceCarButton.gameObject.SetActive(true);
            selectPoliceCarButton.gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt(ambulanceUnlockedKey, 0) == 1){
            buyAmbulanceButton.gameObject.SetActive(false);
            selectAmbulanceButton.gameObject.SetActive(true);
        }else{
            buyAmbulanceButton.gameObject.SetActive(true);
            selectAmbulanceButton.gameObject.SetActive(false);
        }
    }

    public void OnPurchaseComplete(Product product){
        if(product.definition.id == secondCarId)
        {
            PlayerPrefs.SetInt(secondCarUnlockedKey, 1);
            CheckIfBought();
        }
        if(product.definition.id == sedanId)
        {
            PlayerPrefs.SetInt(sedanUnlockedKey, 1);
            CheckIfBought();
        }
        if(product.definition.id == muscleCarId)
        {
            PlayerPrefs.SetInt(muscleCarUnlockedKey, 1);
            CheckIfBought();
        }
        if(product.definition.id == vanId)
        {
            PlayerPrefs.SetInt(vanUnlockedKey, 1);
            CheckIfBought();
        }
        if(product.definition.id == policeCarId)
        {
            PlayerPrefs.SetInt(policeCarUnlockedKey, 1);
            CheckIfBought();
        }
        if(product.definition.id == ambulanceId)
        {
            PlayerPrefs.SetInt(ambulanceUnlockedKey, 1);
            CheckIfBought();
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription reason){
        Debug.LogWarning($"Failed to purchase product {product.definition.id} because {reason}");
    }

    public void SelectDefaultCar(){
        PlayerPrefs.SetInt(secondCarUseKey,  0);
        PlayerPrefs.SetInt(sedanUseKey,  0);
        PlayerPrefs.SetInt(muscleCarUseKey,  0);
        PlayerPrefs.SetInt(vanUseKey,  0);
        PlayerPrefs.SetInt(policeCarUseKey,  0);
        PlayerPrefs.SetInt(ambulanceUseKey,  0);
    }

    public void SelectSecondCar(){
        PlayerPrefs.SetInt(secondCarUseKey, 1);
        PlayerPrefs.SetInt(sedanUseKey,  0);
        PlayerPrefs.SetInt(muscleCarUseKey,  0);
        PlayerPrefs.SetInt(vanUseKey,  0);
        PlayerPrefs.SetInt(policeCarUseKey,  0);
        PlayerPrefs.SetInt(ambulanceUseKey,  0);
    }

    public void SelectSedan(){
        PlayerPrefs.SetInt(secondCarUseKey, 0);
        PlayerPrefs.SetInt(sedanUseKey,  1);
        PlayerPrefs.SetInt(muscleCarUseKey,  0);
        PlayerPrefs.SetInt(vanUseKey,  0);
        PlayerPrefs.SetInt(policeCarUseKey,  0);
        PlayerPrefs.SetInt(ambulanceUseKey,  0);
    }

    public void SelectMuscleCar(){
        PlayerPrefs.SetInt(secondCarUseKey, 0);
        PlayerPrefs.SetInt(sedanUseKey,  0);
        PlayerPrefs.SetInt(muscleCarUseKey,  1);
        PlayerPrefs.SetInt(vanUseKey,  0);
        PlayerPrefs.SetInt(policeCarUseKey,  0);
        PlayerPrefs.SetInt(ambulanceUseKey,  0);
    }

    public void SelectVan(){
        PlayerPrefs.SetInt(secondCarUseKey, 0);
        PlayerPrefs.SetInt(sedanUseKey,  0);
        PlayerPrefs.SetInt(muscleCarUseKey,  0);
        PlayerPrefs.SetInt(vanUseKey,  1);
        PlayerPrefs.SetInt(policeCarUseKey,  0);
        PlayerPrefs.SetInt(ambulanceUseKey,  0);
    }

    public void SelectPoliceCar(){
        PlayerPrefs.SetInt(secondCarUseKey, 0);
        PlayerPrefs.SetInt(sedanUseKey,  0);
        PlayerPrefs.SetInt(muscleCarUseKey,  0);
        PlayerPrefs.SetInt(vanUseKey,  0);
        PlayerPrefs.SetInt(policeCarUseKey,  1);
        PlayerPrefs.SetInt(ambulanceUseKey,  0);
    }

    public void SelectAmbulance(){
        PlayerPrefs.SetInt(secondCarUseKey, 0);
        PlayerPrefs.SetInt(sedanUseKey,  0);
        PlayerPrefs.SetInt(muscleCarUseKey,  0);
        PlayerPrefs.SetInt(vanUseKey,  0);
        PlayerPrefs.SetInt(policeCarUseKey,  0);
        PlayerPrefs.SetInt(ambulanceUseKey,  1);
    }
    
}
