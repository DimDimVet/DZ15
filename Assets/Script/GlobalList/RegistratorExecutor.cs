using System;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class RegistratorExecutor : MonoBehaviour
{
    List<RegistratorConstruction> DataList=new List<RegistratorConstruction>();
    private void OnEnable()
    {
        OnUpDateData+=


        DataList =GetDataList();
        OnDataList += ThisOnDataList;//���������� �� ������ ������ �������� GetDataList

                                        //OnGetDataPlayer += ThisGetDataPlayer;//���������� �� ������ ������ �������� Player
                                        //MovePlayer.OnGetDataCamera+=GetDataCamera;//���������� �� ������ ������ �������� Camera
                                        //CameraMove.OnGetDataPlayer+=GetDataPlayer;//���������� �� ������ ������ �������� Player
                                        //Healt.OnGetNetManager+=NetManager;//���������� �� ������ ������ �������� NetManager
                                        //PickUpItem.OnGetNetManager += NetManager;//���������� �� ������ ������ �������� NetManager
                                        //PickUpItem.OnGetData+=GetData; //���������� �� ������ ������ �������� GetData
                                        //PickUpItem.OnInventory+=Inventory;//���������� �� ������ ������ �������� Inventory
                                        //PlayerHealt.OnGetNetManager+=NetManager;//���������� �� ������ ������ �������� NetManager
                                        //CountText.OnGetDataPlayer+=GetDataPlayer;//���������� �� ������ ������ �������� Player
                                        //NetworkManager.OnGetDataList+=GetDataList;//���������� �� ������ ������ �������� GetDataList
                                        //PullPlayer.OnGetDataPlayer +=GetDataPlayer;//���������� �� ������ ������ �������� Player
                                        //ShootPlayer.OnGetDataPlayer +=GetDataPlayer;//���������� �� ������ ������ �������� Player
                                        //ShootPlayer.OnGetNetManager +=NetManager;//���������� �� ������ ������ �������� NetManager
                                        //AnimPlayer.OnGetDataPlayer+=GetDataPlayer;//���������� �� ������ ������ �������� Player
                                        //Bull.OnGetData+=GetData;//���������� �� ������ ������ �������� GetData
 
    }
    private void OnDisable()//�������
    {
        OnDataList -= ThisOnDataList;
        //OnGetDataPlayer -= ThisGetDataPlayer;
        //MovePlayer.OnGetDataCamera-=GetDataCamera;
        //CameraMove.OnGetDataPlayer-=GetDataPlayer;
        //Healt.OnGetNetManager-=NetManager;
        //PickUpItem.OnGetNetManager -= NetManager;
        //PickUpItem.OnGetData-=GetData;
        //PickUpItem.OnInventory-=Inventory;
        //CountText.OnGetDataPlayer-=GetDataPlayer;
        //NetworkManager.OnGetDataList-=GetDataList;
        //PullPlayer.OnGetDataPlayer -=GetDataPlayer;
        //ShootPlayer.OnGetDataPlayer -=GetDataPlayer;
        //ShootPlayer.OnGetNetManager -=NetManager;
        //AnimPlayer.OnGetDataPlayer-=GetDataPlayer;
        //Bull.OnGetData-=GetData;

    }
    
    private void ThisOnDataList(List<RegistratorConstruction> list)
    {
        DataList = list;
        for (int i = 0; i < DataList.Count; i++)
        {
            Debug.Log(DataList[i]);
        }
    }

    //private Transform OutPos { get; set; }

    //private RegistratorConstruction GetData(int hash)
    //{
    //    for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
    //    {
    //        if (RegistratorList.DataObjects[i].Hash == hash)
    //        {
    //            return RegistratorList.DataObjects[i];
    //        }
    //    }
    //    return new RegistratorConstruction();
    //}

    //private RegistratorConstruction GetDataCamera()
    //{
    //    for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
    //    {
    //        if (RegistratorList.DataObjects[i].CameraMove != null)
    //        {
    //            return RegistratorList.DataObjects[i];
    //        }
    //    }
    //    return new RegistratorConstruction();
    //}

    //private RegistratorConstruction ThisGetDataPlayer()
    //{
    //    for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
    //    {
    //        //if (RegistratorList.DataObjects[i].PhotonIsMainGO && RegistratorList.DataObjects[i].UserInput!=null)
    //        //{
    //        //    return RegistratorList.DataObjects[i];
    //        //}
    //    }
    //    return new RegistratorConstruction();
    //}
    //private RegistratorConstruction NetManager()
    //{
    //    for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
    //    {
    //        if (RegistratorList.DataObjects[i].NetworkManager !=null)
    //        {
    //            return RegistratorList.DataObjects[i];
    //        }
    //    }
    //    return new RegistratorConstruction();
    //}

    //private RegistratorConstruction Inventory()
    //{
    //    for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
    //    {
    //        if (RegistratorList.DataObjects[i].ControlInventory != null)
    //        {
    //            return RegistratorList.DataObjects[i];
    //        }
    //    }
    //    return new RegistratorConstruction();
    //}

    //private void DestroyObject(RegistratorConstruction go)
    //{
    //    RegistratorConstruction tempGO = new RegistratorConstruction();
    //    tempGO = go;
    //    tempGO.IsDestroyGO = true;

    //    for (int i = 0; i < RegistratorList.DataObjects.Count; i++)
    //    {
    //        //if (RegistratorList.DataObjects[i].PhotonHash == tempGO.PhotonHash)
    //        //{
    //        //    RegistratorList.DataObjects.Remove(tempGO);
    //        //}
    //    }
    //}
}
