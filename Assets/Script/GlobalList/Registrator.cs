using Photon.Pun;
using UnityEngine;
using static EventManager;

public class Registrator : MonoBehaviour
{
    [Header("Загрузить текущий объект")]
    [SerializeField] private MonoBehaviour thisGO;

    private void Start()
    {
        if (thisGO==null)
        {
            thisGO = gameObject.GetComponent<MonoBehaviour>();
            if (thisGO == null)
            {
                return;
            }
        }
        //соберем экземпляр объекта
        RegistratorConstruction registrator = new RegistratorConstruction();

        if (registrator.Hash ==0) { registrator.Hash = GetHashCode(); }
        if (thisGO is Healt) { registrator.Healt = (Healt)thisGO; }
        if (thisGO is ControlInventory) {registrator.ControlInventory = (ControlInventory)thisGO; }
        if (thisGO is PlayerHealt) { registrator.PlayerHealt = (PlayerHealt)thisGO; }
        if (thisGO is ShootPlayer) { registrator.ShootPlayer = (ShootPlayer)thisGO; }
        if (thisGO is CameraMove) { registrator.CameraMove = (CameraMove)thisGO; }
        if (thisGO is UserInput) { registrator.UserInput = (UserInput)thisGO; }
        if (thisGO is NetworkManager) { registrator.NetworkManager = (NetworkManager)thisGO; }
        if (thisGO is PickUpItem) { registrator.PickUpItem = (PickUpItem)thisGO; }
        if (thisGO is PhotonView) { registrator.PhotonView = (PhotonView)thisGO; }

        SetData(registrator);//записали в лист
    }

}
