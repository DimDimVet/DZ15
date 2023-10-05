using Photon.Pun;
using System;
using Unity.Mathematics;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    //event
    public static event Func<RegistratorConstruction> OnGetDataPlayer;

    [SerializeField] private AnimSettings animSettings;

    private RegistratorConstruction rezultListInput;

    //anim
    private float speed;
    private string animSpeed;
    private string animJamp;
    private string animDead;

    private Animator animator;

    private float refDistance = 0.01f;
    private float2 distans;

    private bool isRun;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //ищем управление
        //rezultListInput = GetInput();

        speed = animSettings.Speed;
        animSpeed = animSettings.AnimSpeed;
        animJamp = animSettings.AnimJamp;
        animDead = animSettings.AnimDead;

    }

    //private RegistratorConstruction GetInput()
    //{
    //    return (RegistratorConstruction)(OnGetDataPlayer?.Invoke());
    //}
    private bool ControlGO()
    {

        if (rezultListInput.Healt != null)
        {
            return rezultListInput.Healt.Dead;
        }
        if (rezultListInput.PlayerHealt != null)
        {
            return rezultListInput.PlayerHealt.Dead;
        }

        return false;
    }
    void Update()
    {
        //ищем если не нашли
        if (isRun == false)
        {
            //rezultListInput = GetInput();
            //if (rezultListInput.PhotonIsMainGO)
            //{
            //    if (rezultListInput.UserInput != null)
            //    {
            //        isRun = rezultListInput.PhotonIsMainGO;
            //    }
            //}
        }

        if (PhotonView.Get(this.gameObject).IsMine && isRun)
        {
            //if (rezultListInput.PhotonIsMainGO == false)
            //{
            //    rezultListInput = GetInput();
            //    return;
            //}

            distans.x = Mathf.Abs(rezultListInput.UserInput.InputData.Move.x);
            distans.y = Mathf.Abs(rezultListInput.UserInput.InputData.Move.y);

            if (distans.x >= refDistance | distans.y >= refDistance)
            {
                animator.SetFloat(animSpeed, speed * math.distancesq(distans.x, -distans.y));
            }
            else
            {
                animator.SetFloat(animSpeed, 0);
            }

            //pull
            //реакция на изменеия, запустим анимацию 
            if (rezultListInput.UserInput.InputData.Pull > 0f)
            {
                animator.SetBool(animJamp, true);
            }
            else
            {
                animator.SetBool(animJamp, false);
            }

            ////dead
            if (ControlGO())
            {
                animator.SetBool(animDead, true);
            }
        }
    }
}
