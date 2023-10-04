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

    private bool isMove = false;//���������� �� ������� ��������
    private bool isRun = false;//���������� �� ������

    private void OnEnable()
    {
        speedMove = moveSettings.SpeedMove;

        UserInput.OnEventMove += EventMove;//����������, � ������ ����� ��������
    }
    private void OnDisable()//�������
    {
        UserInput.OnEventMove -= EventMove;
    }
    private void OnDestroy()//�������
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

    private void GetConnectEvent()//�������� ���������� �� ���������� ������ �� �����
    {
        if (isRun == false)//���� ����� ���������� �� ������ false
        {
            rezultListInput = GetInput();//�������� ������ �� �����
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
        if (PhotonView.Get(this.gameObject).IsMine && isRun)//�������� �������������� �������� ������� � ����������
        {
            //������
            rezultListCamera.CameraMove.GetTransformPointCamera = transformCamera;
            angleCamera = rezultListCamera.CameraMove.AngleCamera;
            //���
            transform.Rotate(Vector3.up, angleCamera.x);//������� �����
            transformCamera = cameraPoint;
            //������ � ������
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
        if (!isRun)//���� ��� ����������, �������� ���������� ����
        {
            GetConnectEvent();
            return;//�� ������������ ���� �� ����� ������ ������ ��������
        }

        if (isMove)//���� ���� �������, ������� �����
        {
            Move();
        }
    }
}

