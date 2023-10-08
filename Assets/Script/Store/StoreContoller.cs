using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class StoreContoller : IStore
{
    public void FinishTransaction(ProductDefinition product, string transactionId)
    {
        throw new System.NotImplementedException();
    }

    public void Initialize(IStoreCallback callback)
    {
        throw new System.NotImplementedException();
    }

    public void Purchase(ProductDefinition product, string developerPayload)
    {
        throw new System.NotImplementedException();
    }

    public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products)
    {
        throw new System.NotImplementedException();
    }
}
