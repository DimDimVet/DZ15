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
        print($"Куплен {PurchaseID1}");
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureDescription reason)
    {
        print($"Покупка продукта {product.definition.id} ошибка {reason}");
    }
}
