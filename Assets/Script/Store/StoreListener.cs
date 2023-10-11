using UnityEngine;
using UnityEngine.Purchasing;

public class StoreListener /*: IStoreListener*/
{
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("Оплата прошла");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Оплата прошла");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("Оплата прошла");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Купил {product}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {

        throw new System.NotImplementedException();
    }
}
