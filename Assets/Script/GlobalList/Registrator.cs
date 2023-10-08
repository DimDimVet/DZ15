using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class Registrator : RegistratorGo
{
    private List<RegistratorConstruction> list;
    [SerializeField] private bool isTest=false;//для теста

    private void Start()
    {
        //соберем экземпляр объекта
        RegistratorConstruction registrator = new RegistratorConstruction
        {
            Hash = gameObject.GetHashCode(),
            Healt = GetComponent<Healt>() ,
            UserInput = GetComponent<UserInput>() ,
            ShootPlayer = GetComponent<ShootPlayer>() ,
            CameraMove = GetComponent<CameraMove>() ,
            ControlInventory = GetComponent<ControlInventory>() ,
            NetworkManager = GetComponent<NetworkManager>() ,
            PickUpItem = GetComponent<PickUpItem>() ,
            PhotonView = GetComponent<PhotonView>() 
        };
       
        SetData(registrator);//записали в лист
    }

    private void Update()//для тест
    {
        if (isTest)
        {
            list = GetData();
            for (int i = 0; i < list.Count; i++)
            {
                int? arg= list[i].Hash;
                if (arg != null)
                {
                    Debug.Log($"{arg.Value} {list[i].Healt} {list[i].ControlInventory}" +
                        $"{list[i].ShootPlayer} {list[i].CameraMove} {list[i].UserInput} {list[i].NetworkManager}" +
                        $"{list[i].PickUpItem} {list[i].PhotonView}");
                }
            }
        }
    }

}
