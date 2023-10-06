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
            Hash = GetHashCode(),
            Healt = GetComponent<Healt>() /*(Healt)thisGO*/,
            PlayerHealt = GetComponent<PlayerHealt>() /*(PlayerHealt)thisGO*/,
            UserInput = GetComponent<UserInput>() /*(UserInput)thisGO*/,
            ShootPlayer = GetComponent<ShootPlayer>() /*(ShootPlayer)thisGO*/,
            CameraMove = GetComponent<CameraMove>() /*(CameraMove)thisGO*/,
            ControlInventory = GetComponent<ControlInventory>() /*(ControlInventory)thisGO*/,
            NetworkManager = GetComponent<NetworkManager>() /*(NetworkManager)thisGO*/,
            PickUpItem = GetComponent<PickUpItem>() /*(PickUpItem)thisGO*/,
            PhotonView = GetComponent<PhotonView>() /*(PhotonView)thisGO*/
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
                    Debug.Log($"{arg.Value} {list[i].Healt} {list[i].PlayerHealt} {list[i].ControlInventory}" +
                        $"{list[i].ShootPlayer} {list[i].CameraMove} {list[i].UserInput} {list[i].NetworkManager}" +
                        $"{list[i].PickUpItem} {list[i].PhotonView}");
                }
            }
        }
    }

}
