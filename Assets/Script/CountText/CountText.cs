using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CountText : MonoBehaviour
{
    [SerializeField] private Text textHealt;
    [SerializeField] private Text textCountBull;

    private IRegistrator dataReg;
    private RegistratorConstruction rezultListPlayer;

    private bool isRun;
    void Start()
    {
        dataReg = new RegistratorExecutor();//������ � �����
        rezultListPlayer = dataReg.GetDataPlayer();
    }

    void Update()
    {

        //���� ���� �� �����
        if (isRun == false)
        {
            rezultListPlayer = dataReg.GetDataPlayer();
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
