using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    //event
    public static event Func<int,RegistratorConstruction> OnGetData;
    public static event Func<RegistratorConstruction> OnInventory;
    public static event Func<RegistratorConstruction> OnGetNetManager;

    public PickSettings PickSettings;
    [SerializeField] private GameObject objectImg;
    private GameObject objectGrid;

    private Collider collaider;

    private RegistratorConstruction rezultList;
    private RegistratorConstruction rezultGrid;
    private RegistratorConstruction rezultNetManager;
    void Start()
    {
        collaider = gameObject.GetComponent<Collider>();
        collaider.isTrigger = true;

    }

    private RegistratorConstruction GetData(int hash)
    {
        return (RegistratorConstruction)(OnGetData?.Invoke(hash));
    }
    private RegistratorConstruction Inventory()
    {
        return (RegistratorConstruction)(OnInventory?.Invoke());
    }
    private RegistratorConstruction GetNetManager()
    {
        return (RegistratorConstruction)(OnGetNetManager?.Invoke());
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (PhotonView.Get(this.gameObject).IsMine)
        //{
            int tempHsh = other.gameObject.GetHashCode();
            ExecutorCollision(tempHsh);

            collaider.enabled = false;
            DestoyGO();
            //Destroy(gameObject, 1);
        //}
    }
    private void ExecutorCollision(int hash)
    {
        rezultList = GetData(hash);

        rezultGrid = Inventory();
        objectGrid= rezultGrid.ControlInventory.gameObject;
        //Healt
       
        if (rezultGrid.ControlInventory != null)
        {
            Debug.Log("Лут взял - "+ rezultList.PhotonHash);
            if (rezultGrid.ControlInventory.GridPlater == rezultList.PhotonHash)
            {
                GameObject.Instantiate(objectImg, rezultGrid.ControlInventory.gridTransform);
            }
            
        }
        else
        {
            Debug.Log("No Script" + rezultList.Name);
        }
    }

    public void DestoyGO()
    {
        rezultNetManager = GetNetManager();
        rezultNetManager.NetworkManager.DestroyThisLut(this.gameObject);
    }
}
