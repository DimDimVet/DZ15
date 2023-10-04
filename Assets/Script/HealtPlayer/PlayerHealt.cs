using System;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    //event
    public static event Func<RegistratorConstruction> OnGetNetManager;

    [SerializeField] private HealtSetting settingsData;

    [HideInInspector] public int HealtCount;
    [HideInInspector] public int Damage;
    [HideInInspector] public bool Dead = false;

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
            HealtCount -= Damage;
            if (HealtCount <= 0)
            {
                Dead = true;
                DestoyGO();
                //isOneTriger = false;
            }
            Damage = 0;
        }
    }

    public void DestoyGO()
    {
        rezultNetManager = GetNetManager();
        rezultNetManager.NetworkManager.DestroyThisGO(this.gameObject);
    }
}
