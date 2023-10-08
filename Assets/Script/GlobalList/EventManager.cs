using System;
using UnityEngine;

public class EventManager
{
    //������ ����� Camera
    public static Func<RegistratorConstruction> OnGetCamera;//�������� �� ������������ ����
    public static RegistratorConstruction GetCamera()
    {
        return (RegistratorConstruction)OnGetCamera?.Invoke();//�������� �� ������������ ����
    }

    //������ ����� Player
    public static Func<RegistratorConstruction> OnGetPlayer;//�������� �� ������������ ����
    public static RegistratorConstruction GetPlayer()
    {
        return (RegistratorConstruction)OnGetPlayer?.Invoke();//�������� �� ������������ ����
    }

    //������ ����� ������� �� hash
    public static Func<int,RegistratorConstruction> OnGetObjectHash;//�������� �� ������������ ����
    public static RegistratorConstruction GetObjectHash(int hash)
    {
        return (RegistratorConstruction)OnGetObjectHash?.Invoke(hash);//�������� �� ������������ ����
    }

    //�������� ����� �� hash
    public static Action<int, int> OnGetDamageHash;//�������� �� ������������ ����
    public static void GetDamageHash(int hash, int damage)
    {
        OnGetDamageHash?.Invoke(hash, damage);//�������� �� ������������ ����
    }

    //������ ����� NetPhoton
    public static Func<RegistratorConstruction> OnGetNetworkManager;//�������� �� ������������ ����
    public static RegistratorConstruction GetNetworkManager()
    {
        return (RegistratorConstruction)OnGetNetworkManager?.Invoke();//�������� �� ������������ ����
    }

    //������ ��������
    public delegate void Trigers();
    public static event Trigers OnTrigerCount;//�������� �� ������������ ����
    public static void TrigerCount()
    {
        OnTrigerCount?.Invoke();//�������� �� ������������ ����
    }

}
