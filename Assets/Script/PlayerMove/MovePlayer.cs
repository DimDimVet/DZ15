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
    private Vector3 currentPosition;
    private int gg;

    private bool isRun;
    void Start()
    {
        speedMove = moveSettings.SpeedMove;
        //ищем камеру и управление
        rezultListInput = GetInput();
        rezultListCamera = GetCamera();

    }

    private RegistratorConstruction GetInput()
    {
        return (RegistratorConstruction)(OnGetDataPlayer?.Invoke());
    }
    private RegistratorConstruction GetCamera()
    {
        return (RegistratorConstruction)(OnGetDataCamera?.Invoke());
    }

    private void Move()
    {
        //ищем если не нашли
        if (isRun == false)
        {
            rezultListInput = GetInput();

            if (rezultListInput.UserInput != null)
            {
                isRun=true;
            }
        }


        if (PhotonView.Get(this.gameObject).IsMine && isRun)/*PhotonView.Get(this.gameObject).IsMine*/
        {
            //ищем если не нашли
            if (rezultListCamera.CameraMove == null)
            {
                rezultListCamera = GetCamera();

                return;
            }

            rezultListCamera.CameraMove.GetTransformPointCamera = transformCamera;
            angleCamera = rezultListCamera.CameraMove.AngleCamera;

            transform.Rotate(Vector3.up, angleCamera.x);//поворот мышью
            transformCamera = cameraPoint;


            if (rezultListInput.UserInput.InputData.Move.y > 0)
            {
                currentPosition = transform.position;
                currentPosition += transform.forward / speedMove;
                transform.position = currentPosition;
            }
            if (rezultListInput.UserInput.InputData.Move.y < 0)
            {
                currentPosition = transform.position;
                currentPosition -= transform.forward / speedMove;
                transform.position = currentPosition;
            }

            if (rezultListInput.UserInput.InputData.Move.x > 0)
            {
                currentPosition = transform.position;
                currentPosition += transform.right / speedMove;
                transform.position = currentPosition;
            }
            if (rezultListInput.UserInput.InputData.Move.x < 0)
            {
                currentPosition = transform.position;
                currentPosition -= transform.right / speedMove;
                transform.position = currentPosition;
            }
        }
    }
    private void FixedUpdate()
    {

    }
}

