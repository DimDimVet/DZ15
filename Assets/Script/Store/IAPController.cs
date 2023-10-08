using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAPController : MonoBehaviour
{
    [SerializeField] Button buttonPurchase;
    [SerializeField] string PurchaseID1;
    private void OnEnable()
    {
        buttonPurchase.onClick.AddListener(OnPurchaseCompleted);
    }
    public void OnPurchaseCompleted()
    {
        print(PurchaseID1);
    }
}
