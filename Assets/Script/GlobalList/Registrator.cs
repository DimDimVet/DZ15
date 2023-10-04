using Photon.Pun;
using System;
using UnityEngine;

public class Registrator : MonoBehaviour
{
    [Header("Загрузить скрипт Healt")]
    [SerializeField] private Healt _healt;
    [Header("Загрузить скрипт PlayerHealt")]
    [SerializeField] private PlayerHealt _playerHealt;
    [Header("Загрузить скрипт ShootPlayer")]
    [SerializeField] private ShootPlayer _shootPlayer;
    [Header("Загрузить скрипт CameraMove")]
    [SerializeField] private CameraMove _cameraMove;
    [Header("Загрузить скрипт UserInput")]
    [SerializeField] private UserInput _userInput;
    [Header("Загрузить скрипт ControlInventory")]
    [SerializeField] private ControlInventory _controlInventory;
    [Header("Загрузить скрипт PickUpItem")]
    [SerializeField] private PickUpItem _pickUpItem;
    [Header("Загрузить скрипт NetworkManager")]
    [SerializeField] private NetworkManager _networkManager;
    [Header("Загрузить скрипт PhotonView")]
    [SerializeField] private PhotonView _photonView;

    //event
    /// <summary>
    /// Событие на отправку экземпляра RegistratorConstruction
    /// </summary>
    public static event Action<RegistratorConstruction> OnSetData;

    private void Start()
    {
        //соберем экземпляр объекта
        RegistratorConstruction registrator = new RegistratorConstruction
        {
            IsDestroyGO = false,//&&
            Hash = gameObject.GetHashCode(),
            HealtObj = _healt,
            PlayerHealt = _playerHealt,
            ShootPlayer = _shootPlayer,
            CameraMove = _cameraMove,
            UserInput = _userInput,
            ControlInventory= _controlInventory,
            PickUpItem = _pickUpItem,
            NetworkManager = _networkManager,
            PhotonView = _photonView
        };

        if (PhotonView.Get(this.gameObject) is PhotonView)
        {
            if (registrator.NetworkManager == null)
            {
                registrator.PhotonHash = PhotonView.Get(this.gameObject).ViewID;
                registrator.PhotonIsMainGO = PhotonView.Get(this.gameObject).IsMine;
            }
        }

        SetData(registrator);//создали событие
    }
    private void SetData(RegistratorConstruction registratorConstruction)
    {
        if (registratorConstruction.Hash!=0)
        {
            OnSetData?.Invoke(registratorConstruction);
        }
    }

}
