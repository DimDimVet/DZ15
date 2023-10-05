using System.Collections.Generic;
using UnityEngine;
using static EventManager;

/// <summary>
/// Главный справочник всех нужных объектов
/// </summary>
public class RegistratorList: MonoBehaviour
{
    private List<RegistratorConstruction> DataObjects = new List<RegistratorConstruction>();
    private void OnEnable()//подписки
    {
        OnSetData += SetDataList;
        //OnOutDataList += OutDataList;
    }
    private void OnDisable()//отписки
    {
        OnSetData -= SetDataList;
        //OnOutDataList -= OutDataList;
    }
    private void SetDataList(RegistratorConstruction data)
    {
        DataObjects.Add(data);
    }
    //private List<RegistratorConstruction> OutDataList()
    //{
    //    return DataObjects;
    //}
}
