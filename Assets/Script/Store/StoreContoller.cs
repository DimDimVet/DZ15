using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using static Photon.Pun.Demo.Shared.DocLinks;

public class StoreContoller : IStore
{
    public void FinishTransaction(ProductDefinition product, string transactionId)
    {
        Debug.Log("Оплата прошла");
    }

    public void Initialize(IStoreCallback callback)
    {
    }

    public void Purchase(ProductDefinition product, string developerPayload)
    {
        Debug.Log($"Купил {product}");
    }

    public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products)
    {
        Debug.Log($"Купил {products}");
    }
}
