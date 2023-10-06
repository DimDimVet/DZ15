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

    private bool isRun = false;//разрешение на работу

    private RegistratorConstruction rezultCamera;
    //private RegistratorConstruction rezultPlayer;

    private void OnEnable()
    {
        speedMove = moveSettings.SpeedMove;
    }

    private void GetConnectEvent()//получаем ращрешение по результату данных из листа
    {
        if (isRun == false)//если общее разрешение на запуск false
        {
            //rezultPlayer = GetPlayer();//получаем данные из листа
            rezultCamera = GetCamera();//получаем данные из листа

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
        if (/*PhotonView.Get(this.gameObject).IsMine &&*/ isRun)//проверим принадлежность текущего клиента и разрешение
        {
            //камера
            rezultCamera.CameraMove.GetTransformPointCamera = transformCamera;
            angleCamera = rezultCamera.CameraMove.AngleCamera;
            //мыш
            transform.Rotate(Vector3.up, angleCamera.x);//поворот мышью
            transformCamera = cameraPoint;
            //кнопки и канвас
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
        if (!isRun)//если нет разрешения, пытаемся подключать лист
        {
            GetConnectEvent();
            return;//не подключенный лист не имеет смысла дальше работать
        }

        if (IsMove)//если есть событие, дергаем метод
        {
            Move();
        }
    }
}

