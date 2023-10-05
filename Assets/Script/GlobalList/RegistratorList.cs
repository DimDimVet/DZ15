using System.Collections.Generic;
using UnityEngine;
using static EventManager;

/// <summary>
/// ������� ���������� ���� ������ ��������
/// </summary>
public class RegistratorList: MonoBehaviour
{
    private List<RegistratorConstruction> DataObjects = new List<RegistratorConstruction>();
    private void OnEnable()//��������
    {
        OnSetData += SetDataList;
        //OnOutDataList += OutDataList;
    }
    private void OnDisable()//�������
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
