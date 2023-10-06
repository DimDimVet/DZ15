using System.Collections.Generic;
using static EventManager;

public class RegistratorExecutor :RegistratorGo
{
    private List<RegistratorConstruction> list;

    private void OnEnable()
    {
        OnGetCamera += GetDataCamera;//������� Camera
        OnGetPlayer += GetDataPlayer;//������� Camera
    }

    private void OnDisable()//�������
    {
        OnGetCamera -= GetDataCamera;
        OnGetPlayer -= GetDataPlayer;
    }

    private RegistratorConstruction GetDataPlayer()
    {
        list = GetData();//�������� ������
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
        list = GetData();//�������� ������
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].CameraMove != null)
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
