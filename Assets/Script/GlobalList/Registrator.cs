using Photon.Pun;
using UnityEngine;

public class Registrator : MonoBehaviour
{
    [Header("��������� ������ Healt")]
    [SerializeField] private Healt _healt;
    [Header("��������� ������ PlayerHealt")]
    [SerializeField] private PlayerHealt _playerHealt;
    [Header("��������� ������ ShootPlayer")]
    [SerializeField] private ShootPlayer _shootPlayer;
    [Header("��������� ������ CameraMove")]
    [SerializeField] private CameraMove _cameraMove;
    [Header("��������� ������ UserInput")]
    [SerializeField] private UserInput _userInput;
    [Header("��������� ������ ControlInventory")]
    [SerializeField] private ControlInventory _controlInventory;
    [Header("��������� ������ PickUpItem")]
    [SerializeField] private PickUpItem _pickUpItem;
    [Header("��������� ������ NetworkManager")]
    [SerializeField] private NetworkManager _networkManager;
    [Header("��������� ������ PhotonView")]
    [SerializeField] private PhotonView _photonView;

    //private IRegistrator dataReg;
    private RegistratorConstruction registrator;

    private void Start()
    {
        //dataReg = new RegistratorExecutor();
        registrator = new RegistratorConstruction
        {
            IsDestroyGO = false,
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

        EventRegistrator.OnSetData(registrator);//������� �������


        //dataReg.SetData(registrator);
    }

}
