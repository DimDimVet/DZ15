using Photon.Pun;

public struct RegistratorConstruction//Общий конструктор для глобального листа
{
    public int Hash;
    public bool IsDestroyGO { get; set; }
    public ControlInventory ControlInventory;
    public Healt Healt;
    public ShootPlayer ShootPlayer;
    public CameraMove CameraMove;
    public UserInput UserInput;
    public NetworkManager NetworkManager;
    public PickUpItem PickUpItem;
    public PhotonView PhotonView;

}
