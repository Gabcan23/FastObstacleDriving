using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class Store : MonoBehaviour
{
    private const string secondCarId = "com.rofungames.cdriving.secondcar";
    public const string secondCarUnlockedKey = "SecondCarUnlocked";

    public void OnPurchaseComplete(Product product){
        if(product.definition.id == secondCarId)
        {
            PlayerPrefs.SetInt(secondCarUnlockedKey, 1);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription reason){
        Debug.LogWarning($"Failed to purchase product {product.definition.id} because {reason}");
    }
}
