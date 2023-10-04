using System;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    //event
    public static event Func<RegistratorConstruction> OnGetDataPlayer;

    [SerializeField] private Text textHealt;
    [SerializeField] private Text textCountBull;

    private RegistratorConstruction rezultListPlayer;

    private bool isRun;
    void Start()
    {
        rezultListPlayer = GetInput();
    }
    private RegistratorConstruction GetInput()
    {
        return (RegistratorConstruction)(OnGetDataPlayer?.Invoke());
    }

    void Update()
    {

        //ищем если не нашли
        if (isRun == false)
        {
            rezultListPlayer = GetInput();
            if (rezultListPlayer.PhotonIsMainGO)
            {
                if (rezultListPlayer.UserInput != null)
                {
                    isRun = rezultListPlayer.PhotonIsMainGO;
                }
            }

        }

        if (isRun)
        {
            textHealt.text = $"{rezultListPlayer.PlayerHealt.HealtCount}";

            if (rezultListPlayer.ShootPlayer != null)
            {
                textCountBull.text = $"{rezultListPlayer.ShootPlayer.CountBull}";
            }
        }

    }
}
