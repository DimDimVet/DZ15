using System;
using UnityEngine;

public class Healt : MonoBehaviour
{
    //event
    public static event Func<RegistratorConstruction> OnGetNetManager;

    [SerializeField] private HealtSetting settingsData;

    [HideInInspector] public int HealtCount = 0;
    [HideInInspector] public int Damage;
    [HideInInspector] public bool Dead = false;

    private bool isOneTriger = true;

    private RegistratorConstruction rezultNetManager;

    void Start()
    {
        if (settingsData.Healt != 0)
        {
            HealtCount = settingsData.Healt;
        }
    }
    private RegistratorConstruction GetNetManager()
    {
        return (RegistratorConstruction)(OnGetNetManager?.Invoke());
    }

    void Update()
    {
        if (Damage != 0)
        {
            HealtContoll(Damage);
            Damage = 0;
        }
    }
    public void HealtContoll(int damage)
    {
        HealtCount -= damage;
        if (HealtCount <= 0 && isOneTriger)
        {
            Dead = true;
            DestoyGO();
            isOneTriger = false;
        }
    }

    public void DestoyGO()
    {
        rezultNetManager = GetNetManager();
        rezultNetManager.NetworkManager.DestroyThisGO(this.gameObject);
    }
}
