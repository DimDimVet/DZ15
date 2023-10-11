using UnityEngine;
using UnityEngine.Purchasing;

public class StoreListener /*: IStoreListener*/
{
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("������ ������");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("������ ������");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("������ ������");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"����� {product}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {

        throw new System.NotImplementedException();
    }
}
