using Unity.Mathematics;
using UnityEngine;
using static EventManager;

public class MovePlayer : /*MonoBehaviour*/UserInput
{
    [SerializeField] private MoveSettings moveSettings;
    [SerializeField] private Transform cameraPoint;

    private float speedMove;
    private Transform transformCamera;
    private float2 angleCamera;

    private bool isRun = false;//���������� �� ������

    private RegistratorConstruction rezultCamera;
    //private RegistratorConstruction rezultPlayer;

    private void OnEnable()
    {
        speedMove = moveSettings.SpeedMove;
    }

    private void GetConnectEvent()//�������� ���������� �� ���������� ������ �� �����
    {
        if (isRun == false)//���� ����� ���������� �� ������ false
        {
            //rezultPlayer = GetPlayer();//�������� ������ �� �����
            rezultCamera = GetCamera();//�������� ������ �� �����

            if (/*rezultPlayer.UserInput != null*/IsMove && rezultCamera.CameraMove != null)
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
        if (/*PhotonView.Get(this.gameObject).IsMine &&*/ isRun)//�������� �������������� �������� ������� � ����������
        {
            //������
            rezultCamera.CameraMove.GetTransformPointCamera = transformCamera;
            angleCamera = rezultCamera.CameraMove.AngleCamera;
            //���
            transform.Rotate(Vector3.up, angleCamera.x);//������� �����
            transformCamera = cameraPoint;
            //������ � ������
            if (InputData.Move.y > 0)
            {
                transform.position += transform.forward / speedMove;
            }
            if (InputData.Move.y < 0)
            {
                transform.position -= transform.forward / speedMove;
            }

            if (InputData.Move.x > 0)
            {
                transform.position += transform.right / speedMove;
            }
            if (InputData.Move.x < 0)
            {
                transform.position -= transform.right / speedMove;
            }

        }
    }
    private void FixedUpdate()
    {
        Debug.Log($"{base.IsMove} - {isRun}");
        if (!isRun)//���� ��� ����������, �������� ���������� ����
        {
            GetConnectEvent();
            return;//�� ������������ ���� �� ����� ������ ������ ��������
        }

        if (IsMove)//���� ���� �������, ������� �����
        {
            Move();
        }
    }
}

