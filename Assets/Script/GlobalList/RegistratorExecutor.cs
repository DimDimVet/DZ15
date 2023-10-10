using System.Collections.Generic;
using System.Diagnostics;
using static EventManager;

public class RegistratorExecutor :RegistratorGo
{
    private List<RegistratorConstruction> list;

    private void OnEnable()
    {
        OnGetCamera += GetDataCamera;//отдадим Camera
        OnGetPlayer += GetDataPlayer;//отдадим Player
        OnGetObjectHash += GetDataHash;//отдадим объект по hash
        OnGetNetworkManager += NetManager;//отдадим объект по NetManager
        OnGetInventory += Inventory;//отдадим объект по Inventory
    }

    private void OnDisable()//отписки
    {
        OnGetCamera -= GetDataCamera;
        OnGetPlayer -= GetDataPlayer;
        OnGetObjectHash -= GetDataHash;
        OnGetNetworkManager -= NetManager;
        OnGetInventory -= Inventory;
    }

    private RegistratorConstruction GetDataPlayer()
    {
        list = GetData();//получили данные
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].UserInput != null)
            {
                return list[i];
            }
        }
        return new RegistratorConstruction();
    }

    private RegistratorConstruction GetDataCamera()
    {
        list = GetData();//получили данные
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].CameraMove != null)
            {
                return list[i];
            }
        }
        return new RegistratorConstruction();
    }

    private RegistratorConstruction GetDataHash(int hash)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Hash == hash)
            {
                return list[i];
            }
        }
        return new RegistratorConstruction();
    }

    private RegistratorConstruction NetManager()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].NetworkManager != null)
            {
                return list[i];
            }
        }
        return new RegistratorConstruction();
    }

    private RegistratorConstruction Inventory()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].ControlInventory != null)
            {
                return list[i];
            }
        }
        return new RegistratorConstruction();
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
