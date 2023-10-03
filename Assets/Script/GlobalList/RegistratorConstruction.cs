using Photon.Pun;

public struct RegistratorConstruction//Общий конструктор для глобального листа
{
    public int Hash;
    public int PhotonHash;
    public bool IsDestroyGO { get; set; }
    public bool PhotonIsMainGO;
    public ControlInventory ControlInventory;
    public Healt HealtObj;
    public PlayerHealt PlayerHealt;
    public ShootPlayer ShootPlayer;
    public CameraMove CameraMove;
    public string Name;
    public UserInput UserInput;
    public NetworkManager NetworkManager;
    public PickUpItem PickUpItem;
    public PhotonView PhotonView;

}
