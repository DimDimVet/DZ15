using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using static EventManager;

public class IAPController : MonoBehaviour
{
    [SerializeField] string PurchaseID1;


    public void OnPurchaseCompleted(Product product)
    {
        print($"Куплен {PurchaseID1}");
        IAPController(2);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureDescription reason)
    {
        print($"Покупка продукта {product.definition.id} ошибка {reason}");
    }
}
