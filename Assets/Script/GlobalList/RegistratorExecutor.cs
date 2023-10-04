using System.Collections.Generic;
using UnityEngine;

public class RegistratorExecutor : MonoBehaviour
{
    private void OnEnable()
    {
        Registrator.OnSetData+=SetData;//���������� �� ���������� �������� ��� �������������
        MovePlayer.OnGetDataPlayer+=GetDataPlayer;//���������� �� ������ ������ �������� Player
        MovePlayer.OnGetDataCamera+=GetDataCamera;//���������� �� ������ ������ �������� Camera
        CameraMove.OnGetDataPlayer+=GetDataPlayer;//���������� �� ������ ������ �������� Player
        Healt.OnGetNetManager+=NetManager;//���������� �� ������ ������ �������� NetManager
        PickUpItem.OnGetNetManager += NetManager;//���������� �� ������ ������ �������� NetManager
        PickUpItem.OnGetData+=GetData; //���������� �� ������ ������ �������� GetData
        PickUpItem.OnInventory+=Inventory;//���������� �� ������ ������ �������� Inventory
        PlayerHealt.OnGetNetManager+=NetManager;//���������� �� ������ ������ �������� NetManager
        CountText.OnGetDataPlayer+=GetDataPlayer;//���������� �� ������ ������ �������� Player
        NetworkManager.OnGetDataList+=GetDataList;//���������� �� ������ ������ �������� GetDataList
        PullPlayer.OnGetDataPlayer +=GetDataPlayer;//���������� �� ������ ������ �������� Player
        ShootPlayer.OnGetDataPlayer +=GetDataPlayer;//���������� �� ������ ������ �������� Player
        ShootPlayer.OnGetNetManager +=NetManager;//���������� �� ������ ������ �������� NetManager
        AnimPlayer.OnGetDataPlayer+=GetDataPlayer;//���������� �� ������ ������ �������� Player
        Bull.OnGetData+=GetData;//���������� �� ������ ������ �������� GetData
    }
    private void OnDisable()//�������
    {
        Registrator.OnSetData-=SetData;
        MovePlayer.OnGetDataPlayer-=GetDataPlayer;
        MovePlayer.OnGetDataCamera-=GetDataCamera;
        CameraMove.OnGetDataPlayer-=GetDataPlayer;
        Healt.OnGetNetManager-=NetManager;
        PickUpItem.OnGetNetManager -= NetManager;
        PickUpItem.OnGetData-=GetData;
        PickUpItem.OnInventory-=Inventory;
        CountText.OnGetDataPlayer-=GetDataPlayer;
        NetworkManager.OnGetDataList-=GetDataList;
        PullPlayer.OnGetDataPlayer -=GetDataPlayer;
        ShootPlayer.OnGetDataPlayer -=GetDataPlayer;
        ShootPlayer.OnGetNetManager -=NetManager;
        AnimPlayer.OnGetDataPlayer-=GetDataPlayer;
        Bull.OnGetData-=GetData;
    }

    //private Transform OutPos { get; set; }

    private void SetData(RegistratorConstruction data)
    {
        RegistratorList.DataObjects.Add(data);
    }

    private List<RegistratorConstruction> GetDataList()
    {
        return RegistratorList.DataObjects;
    }

    private RegistratorConstruction GetData(int hash)
    {
        for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
        {
            if (RegistratorList.DataObjects[i].Hash == hash)
            {
                return RegistratorList.DataObjects[i];
            }
        }
        return new RegistratorConstruction();
    }

    private RegistratorConstruction GetDataCamera()
    {
        for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
        {
            if (RegistratorList.DataObjects[i].CameraMove != null)
            {
                return RegistratorList.DataObjects[i];
            }
        }
        return new RegistratorConstruction();
    }

    private RegistratorConstruction GetDataPlayer()
    {
        for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
        {
            if (RegistratorList.DataObjects[i].PhotonIsMainGO && RegistratorList.DataObjects[i].UserInput!=null)
            {
                return RegistratorList.DataObjects[i];
            }
        }
        return new RegistratorConstruction();
    }
    private RegistratorConstruction NetManager()
    {
        for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
        {
            if (RegistratorList.DataObjects[i].NetworkManager !=null)
            {
                return RegistratorList.DataObjects[i];
            }
        }
        return new RegistratorConstruction();
    }

    private RegistratorConstruction Inventory()
    {
        for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
        {
            if (RegistratorList.DataObjects[i].ControlInventory != null)
            {
                return RegistratorList.DataObjects[i];
            }
        }
        return new RegistratorConstruction();
    }

    private void DestroyObject(RegistratorConstruction go)
    {
        RegistratorConstruction tempGO = new RegistratorConstruction();
        tempGO = go;
        tempGO.IsDestroyGO = true;

        for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
        {
            if (RegistratorList.DataObjects[i].PhotonHash == tempGO.PhotonHash)
            {
                RegistratorList.DataObjects.Remove(tempGO);
            }
        }
    }
}
