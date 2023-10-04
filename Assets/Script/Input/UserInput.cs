using System;
using UnityEngine;
using UnityEngine.InputSystem;

public  class UserInput : MonoBehaviour
{
    //event
    public static event Action<bool> OnEventMove;//����� ���������� ������� ��� ����� ��������

    public InputData InputData;//��������� ������
    public bool DebugLogOnOff;//��� ������ //��� ������ � ���������, ��������

    //��� ���������� ������ MapCurrent(new input)
    private MapCurrent inputAction;

    private bool isLook;
    private void OnEnable()
    {
        inputAction = new MapCurrent();//�������������� ����� input
        InputData = new InputData();

        if (inputAction != null)//�������� �� null
        {
            //�������� �� event ������� ������� � �������� �������� ��������� ���������
            inputAction.UIMap.WASD.performed += context => { InputData.Move = context.ReadValue<Vector2>(); };
            inputAction.UIMap.WASD.started += context => { InputData.Move = context.ReadValue<Vector2>(); };
            inputAction.UIMap.WASD.canceled += context => { InputData.Move = context.ReadValue<Vector2>(); };

            inputAction.Map.WASD.performed += context => { InputData.Move = context.ReadValue<Vector2>(); };
            inputAction.Map.WASD.started += context => { InputData.Move = context.ReadValue<Vector2>(); };
            inputAction.Map.WASD.canceled += context => { InputData.Move = context.ReadValue<Vector2>(); };

            inputAction.Map.Look.performed += context => { InputData.Mouse = context.ReadValue<Vector2>(); };
            inputAction.Map.Look.started += context => { InputData.Mouse = context.ReadValue<Vector2>(); };
            inputAction.Map.Look.canceled += context => { InputData.Mouse = context.ReadValue<Vector2>(); };

            inputAction.Map.Shoot.performed += context => { InputData.Shoot = context.ReadValue<float>(); };
            inputAction.Map.Shoot.started += context => { InputData.Shoot = context.ReadValue<float>(); };
            inputAction.Map.Shoot.canceled += context => { InputData.Shoot = context.ReadValue<float>(); };

            inputAction.Map.Pull.performed += context => { InputData.Pull = context.ReadValue<float>(); };
            inputAction.Map.Pull.started += context => { InputData.Pull = context.ReadValue<float>(); };
            inputAction.Map.Pull.canceled += context => { InputData.Pull = context.ReadValue<float>(); };

            inputAction.Map.ModePlayer.performed += context => { InputData.Mode = context.ReadValue<float>(); };
            inputAction.Map.ModePlayer.started += context => { InputData.Mode = context.ReadValue<float>(); };
            inputAction.Map.ModePlayer.canceled += context => { InputData.Mode = context.ReadValue<float>(); };

            //�������� 
            inputAction.Enable();

            //�������� ����������� ������� ��� ���� �������
            inputAction.Map.WASD.performed += PerformedWASD;
            inputAction.Map.WASD.started += PerformedWASD;
            inputAction.Map.WASD.canceled += CanceledWASD;

            inputAction.UIMap.WASD.performed += PerformedWASD;
            inputAction.UIMap.WASD.started += PerformedWASD;
            inputAction.UIMap.WASD.canceled += CanceledWASD;

            inputAction.Map.Look.performed += PerformedLook;
            inputAction.Map.Look.started += PerformedLook;
            inputAction.Map.Look.canceled += CanceledLook;

        }
        else
        {
            Debug.LogError("��� ����� � ������� MapCurrent");
        }
    }

    //���� ���� ������� WASD �� �������� �������
    private void PerformedWASD(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>()!=null)
        {
            OnEventMove?.Invoke(true);
        }
    }
    //���� ������� WASD ����������� �� �������� �������
    private void CanceledWASD(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() != null && isLook==false)
        {
            OnEventMove?.Invoke(false);
        }
    }

    //���� ���� ������� Look �� �������� �������
    private void PerformedLook(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() != null)
        {
            isLook = true;
            OnEventMove?.Invoke(true);
        }
    }
    //���� ������� Look ����������� �� �������� �������
    private void CanceledLook(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() != null)
        {
            isLook=false;
        }
    }


    void Update()
    {
        if (DebugLogOnOff)//��� ������ � ���������, ��������
        {
            Debug.Log($"�������� � = {InputData.Move.x}, �������� Y = {InputData.Move.y}");
            Debug.Log($"���� � = {InputData.Mouse.x}, ���� Y = {InputData.Mouse.y}");
            Debug.Log($"������� = {InputData.Shoot}");
            Debug.Log($"������ = {InputData.Pull}");
            Debug.Log($"����� = {InputData.Mode}");
        }
    }
}
