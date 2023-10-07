using Unity.Mathematics;
using UnityEngine;
using static EventManager;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField] private AnimSettings animSettings;

    private RegistratorConstruction rezultInput;
    //anim
    private float speed;
    private string animSpeed;
    private string animJamp;
    private string animDead;

    private Animator animator;

    private float refDistance = 0.01f;
    private float2 distans;

    private bool isRun;

    private void OnEnable()
    {
        animator = gameObject.GetComponent<Animator>();

        speed = animSettings.Speed;
        animSpeed = animSettings.AnimSpeed;
        animJamp = animSettings.AnimJamp;
        animDead = animSettings.AnimDead;
    }

    private bool ControlGO()
    {

        if (rezultInput.Healt != null)
        {
            return rezultInput.Healt.Dead;
        }
        if (rezultInput.PlayerHealt != null)
        {
            return rezultInput.PlayerHealt.Dead;
        }
        return false;
    }

    private void GetConnectEvent()//получаем ращрешение по результату данных из листа
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            rezultInput = GetPlayer();//получаем данные из листа

            if (rezultInput.UserInput != null)
            {
                isRun = true;
            }
            else
            {
                isRun = false;
                return;
            }
        }
        else
        {
            isRun = true;
        }
    }

    private void MoveActiv()
    {
        if (/*PhotonView.Get(this.gameObject).IsMine &&*/ isRun)
        {
            distans.x = Mathf.Abs(rezultInput.UserInput.InputData.Move.x);
            distans.y = Mathf.Abs(rezultInput.UserInput.InputData.Move.y);

            if (distans.x >= refDistance || distans.y >= refDistance)
            {
                animator.SetFloat(animSpeed, speed * math.distancesq(distans.x, -distans.y));
            }
            else
            {
                animator.SetFloat(animSpeed, 0);
            }

            //pull
            //реакция на изменеия, запустим анимацию 
            if (rezultInput.UserInput.InputData.Pull > 0f)
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

    private void FixedUpdate()
    {
        if (!isRun)//если нет разрешения, пытаемся подключать лист
        {
            GetConnectEvent();
        }
        else
        {
            MoveActiv();
        }
    }
}
