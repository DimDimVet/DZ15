using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

public class IAPController : MonoBehaviour
{
    [SerializeField] Button buttonPurchase;
    [SerializeField] string PurchaseID1;
    public void OnPurchaseCompleted(Product product)
    {
        print($"������ {PurchaseID1}");
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureDescription reason)
    {
        print($"������� �������� {product.definition.id} ������ {reason}");
    }
}
