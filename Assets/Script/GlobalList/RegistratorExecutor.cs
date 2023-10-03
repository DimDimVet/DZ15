using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RegistratorExecutor : MonoBehaviour
{
    void Start()
    {
        EventRegistrator.SetData.AddListener(SetData);//��������
    }

    public Transform OutPos { get; set; }

    
    private void SetData(RegistratorConstruction data)
    {
        GlobalList.DataObject.Add(data);
    }

    public List<RegistratorConstruction> GetDataList()
    {
        return GlobalList.DataObject;
    }

    public RegistratorConstruction GetData(int hash)
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].Hash == hash)
            {
                return GlobalList.DataObject[i];
            }
        }
        return new RegistratorConstruction();
    }

    public RegistratorConstruction GetDataCamera()
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].CameraMove != null)
            {
                return GlobalList.DataObject[i];
            }
        }
        return new RegistratorConstruction();
    }

    public RegistratorConstruction GetDataPlayer()
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].PhotonIsMainGO && GlobalList.DataObject[i].UserInput!=null)
            {
                return GlobalList.DataObject[i];
            }
        }
        return new RegistratorConstruction();
    }
    public RegistratorConstruction NetManager()
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].NetworkManager !=null)
            {
                return GlobalList.DataObject[i];
            }
        }
        return new RegistratorConstruction();
    }

    public RegistratorConstruction Inventory()
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].ControlInventory != null)
            {
                return GlobalList.DataObject[i];
            }
        }
        return new RegistratorConstruction();
    }

    public void DestroyObject(RegistratorConstruction go)
    {
        RegistratorConstruction tempGO = new RegistratorConstruction();
        tempGO = go;
        tempGO.IsDestroyGO = true;

        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].PhotonHash == tempGO.PhotonHash)
            {
                GlobalList.DataObject.Remove(tempGO);
            }  
        }
    }
}
