using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static EventManager;

public class CameraMove : MonoBehaviour
{
    [HideInInspector] public float2 AngleCamera;
    [HideInInspector] public Transform GetTransformPointCamera;
    //
    [SerializeField] private CameraSettings cameraSettings;

    private RegistratorConstruction rezultInput;

    private float2 inputMouse;
    private float yRot;
    private float mouseSensor;
    private float minStopAngle;
    private float maxStopAngle;

    private bool isRun;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //settings
        mouseSensor = cameraSettings.MouseSensor;
        minStopAngle = cameraSettings.MinStopAngle;
        maxStopAngle = cameraSettings.MaxStopAngle;
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
            inputMouse = rezultInput.UserInput.InputData.Mouse;

            AngleCamera = inputMouse * mouseSensor * Time.deltaTime;
            yRot -= AngleCamera.y;
            yRot = Math.Clamp(yRot, minStopAngle, maxStopAngle);
            transform.localRotation = Quaternion.Euler(yRot, 0, 0);

            if (GetTransformPointCamera != null)
            {
                transform.position = GetTransformPointCamera.position/*+setPos*/;//получим позицию объекта привязки
                transform.rotation = GetTransformPointCamera.rotation;
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
