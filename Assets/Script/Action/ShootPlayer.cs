using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    //event
    public static event Func<RegistratorConstruction> OnGetDataPlayer;
    public static event Func<RegistratorConstruction> OnGetNetManager;
    //
    [SerializeField] private ActionSettings actionSettings;
    //
    private RegistratorConstruction rezultListInput;
    private RegistratorConstruction rezulNetManager;

    [HideInInspector] public int CountBull;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform outBullet;

    [SerializeField] private ParticleSystem gunExitParticle;//������� ������

    //������� � ���� �������� �������

    private float shootDelay;
    private float shootTime = float.MinValue;

    //Bulls
    private List<Bull> bulls = new List<Bull>(); //��� ����� ������� ��� ����   

    private void Start()
    {
        //���� ����������
        rezultListInput = GetInput();
        rezulNetManager = GetNetManager();

        //dataReg.OutPos = outBullet;
        shootDelay =actionSettings.ShootDelay;

        InstBulls(10);

        StartCoroutine(Example());

    }
    private RegistratorConstruction GetInput()
    {
        return (RegistratorConstruction)(OnGetDataPlayer?.Invoke());
    }
    private RegistratorConstruction GetNetManager()
    {
        return (RegistratorConstruction)(OnGetNetManager?.Invoke());
    }

    private void InstBulls(int count)
    {
        for (int i = 0; i < count; i++) 
        {
            GameObject bulle =Instantiate(bullet, outBullet.position, outBullet.rotation);
            Bull scriptBulle = bulle.GetComponent<Bull>();

            scriptBulle.isSet = false;
            bulls.Add(scriptBulle);
        }
    }



    void Update()
    {
        if (PhotonView.Get(this.gameObject).IsMine)
        {
            if (rezultListInput.UserInput == null)
            {
                rezultListInput = GetInput();
                return;
            }

            if (rezultListInput.UserInput.InputData.Shoot != 0)//������� �������
            {
                Shoot();
            }
        }
        
    }
    private IEnumerator Example()
    {
        int i = 0;
        while (i < 3)
        {
            yield return new WaitForSeconds(0.2f);
            i++;
        }
    }

    public void Shoot()
    {
        if (Time.time < shootTime + shootDelay)
        {
            return;
        }
        else
        {
            shootTime = Time.time;
        }

        //bullFactory.Create();
        CountBull++;
        for (int i = 0; i < bulls.Count; i++)
        {
            if (bulls[i].isSet==false)
            {
                bulls[i].ShootBull(true, outBullet);
                return;
            }
        }
    }
}
