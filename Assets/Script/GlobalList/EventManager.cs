using System;
using UnityEngine;

public class EventManager
{
    //запрос листа Camera
    public static Func<RegistratorConstruction> OnGetCamera;//запросим из пространства лист
    public static RegistratorConstruction GetCamera()
    {
        return (RegistratorConstruction)OnGetCamera?.Invoke();//запросим из пространства лист
    }

    //запрос листа Player
    public static Func<RegistratorConstruction> OnGetPlayer;//запросим из пространства лист
    public static RegistratorConstruction GetPlayer()
    {
        return (RegistratorConstruction)OnGetPlayer?.Invoke();//запросим из пространства лист
    }

    //запрос листа объекта по hash
    public static Func<int,RegistratorConstruction> OnGetObjectHash;//запросим из пространства лист
    public static RegistratorConstruction GetObjectHash(int hash)
    {
        return (RegistratorConstruction)OnGetObjectHash?.Invoke(hash);//запросим из пространства лист
    }

    //передача урона по hash
    public static Action<int, int> OnGetDamageHash;//запросим из пространства лист
    public static void GetDamageHash(int hash, int damage)
    {
        OnGetDamageHash?.Invoke(hash, damage);//запросим из пространства лист
    }

    //запрос листа NetPhoton
    public static Func<RegistratorConstruction> OnGetNetworkManager;//запросим из пространства лист
    public static RegistratorConstruction GetNetworkManager()
    {
        return (RegistratorConstruction)OnGetNetworkManager?.Invoke();//запросим из пространства лист
    }

    //тригер счетчика
    public delegate void Trigers();
    public static event Trigers OnTrigerCount;//запросим из пространства лист
    public static void TrigerCount()
    {
        OnTrigerCount?.Invoke();//запросим из пространства лист
    }

}
