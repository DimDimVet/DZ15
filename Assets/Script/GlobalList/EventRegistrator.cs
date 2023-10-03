using System.Collections.Generic;
using UnityEngine.Events;

public class EventRegistrator
{
    //������ ������
    public static readonly UnityEvent<RegistratorConstruction> SetData=new UnityEvent<RegistratorConstruction>();
    public static void OnSetData(RegistratorConstruction registratorConstruction)
    {
        SetData?.Invoke(registratorConstruction);
    }

    //�������� ���� ������
    public static readonly UnityEvent<List<RegistratorConstruction>> GetDataList = new UnityEvent<List<RegistratorConstruction>>();
    public static void OnGetDataList(List<RegistratorConstruction> registratorList)
    {
        GetDataList?.Invoke(registratorList);
    }
}
