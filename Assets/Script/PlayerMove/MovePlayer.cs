using Photon.Pun;
using System;
using Unity.Mathematics;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //event
    public static event Func<RegistratorConstruction> OnGetDataPlayer;
    public static event Func<RegistratorConstruction> OnGetDataCamera;

    [SerializeField] private MoveSettings moveSettings;
    [SerializeField] private Transform cameraPoint;

    private RegistratorConstruction rezultListCamera;
    private RegistratorConstruction rezultListInput;

    private float speedMove;
    private Transform transformCamera;
    private float2 angleCamera;

    private bool isMove = false;//разрешение на событие движения
    private bool isRun = false;//разрешение на работу

    private void OnEnable()
    {
        speedMove = moveSettings.SpeedMove;

        UserInput.OnEventMove += EventMove;//подпишемся, в случае факта движения
    }
    private void OnDisable()//отписки
    {
        UserInput.OnEventMove -= EventMove;
    }
    private void OnDestroy()//отписки
    {
        UserInput.OnEventMove -= EventMove;
    }

    private RegistratorConstruction GetInput()
    {
        return (RegistratorConstruction)(OnGetDataPlayer?.Invoke());
    }
    private RegistratorConstruction GetCamera()
    {
        return (RegistratorConstruction)(OnGetDataCamera?.Invoke());
    }

    private void EventMove(bool isMove)
    {
        this.isMove = isMove;
    }

    private void GetConnectEvent()//получаем ращрешение по результату данных из листа
    {
        if (isRun == false)//если общее разрешение на запуск false
        {
            rezultListInput = GetInput();//получаем данные из листа
            rezultListCamera = GetCamera();
            if (rezultListInput.UserInput != null && rezultListCamera.CameraMove != null)
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
    private void Move()
    {
        if (PhotonView.Get(this.gameObject).IsMine && isRun)//проверим принадлежность текущего клиента и разрешение
        {
            //камера
            rezultListCamera.CameraMove.GetTransformPointCamera = transformCamera;
            angleCamera = rezultListCamera.CameraMove.AngleCamera;
            //мыш
            transform.Rotate(Vector3.up, angleCamera.x);//поворот мышью
            transformCamera = cameraPoint;
            //кнопки и канвас
            if (rezultListInput.UserInput.InputData.Move.y > 0)
            {
                transform.position += transform.forward / speedMove;
            }
            if (rezultListInput.UserInput.InputData.Move.y < 0)
            {
                transform.position -= transform.forward / speedMove;
            }

            if (rezultListInput.UserInput.InputData.Move.x > 0)
            {
                transform.position += transform.right / speedMove;
            }
            if (rezultListInput.UserInput.InputData.Move.x < 0)
            {
                transform.position -= transform.right / speedMove;
            }

        }
    }
    private void FixedUpdate()
    {
        if (!isRun)//если нет разрешения, пытаемся подключать лист
        {
            GetConnectEvent();
            return;//не подключенный лист не имеет смысла дальше работать
        }

        if (isMove)//если есть событие, дергаем метод
        {
            Move();
        }
    }
}

