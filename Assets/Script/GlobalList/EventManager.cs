using System;
using System.Collections.Generic;

public class EventManager /*: MonoBehaviour*/
{
    //event
    /// <summary>
    /// ������� �� �������� ���������� RegistratorConstruction
    /// </summary>
    public static event Action<RegistratorConstruction> OnSetData;
    public static event Action OnUpDateData;
    public static void SetData(RegistratorConstruction registratorConstruction)
    {
        OnSetData?.Invoke(registratorConstruction);

    }
    public static void UpDateData()
    {
        OnUpDateData?.Invoke();
    }

    //event
    /// <summary>
    /// ������� ��������� ������ List<RegistratorConstruction>
    /// </summary>
    public static event Func<List<RegistratorConstruction>> OnOutDataList;
    //public static event Action<List<RegistratorConstruction>> OnDataList;
    public static List<RegistratorConstruction> GetDataList()
    {
        return (List<RegistratorConstruction>)(OnOutDataList?.Invoke());
    }
    //public static void DataList(List<RegistratorConstruction> list)
    //{
    //    OnDataList?.Invoke(list);
    //}
    //event
    /// <summary>
    /// ������� ��������� ������ GetDataPlayer
    /// </summary>
    public static event Func<RegistratorConstruction> OnGetDataPlayer;
    public static RegistratorConstruction GetInput()
    {
        return (RegistratorConstruction)(OnGetDataPlayer?.Invoke());
    }
    //event
    /// <summary>
    /// ������� ��������� ������ GetDataCamera
    /// </summary>
    public static event Func<RegistratorConstruction> OnGetDataCamera;
    public static RegistratorConstruction GetCamera()
    {
        return (RegistratorConstruction)(OnGetDataCamera?.Invoke());
    }
}
