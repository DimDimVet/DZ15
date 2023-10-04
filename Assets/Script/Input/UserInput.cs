using System;
using UnityEngine;
using UnityEngine.InputSystem;

public  class UserInput : MonoBehaviour
{
    //event
    public static event Action<bool> OnEventMove;//Хотим отправлять события при факте движения

    public InputData InputData;//Передадим данные
    public bool DebugLogOnOff;//для тестов //для вывода в инспектор, временно

    //Кэш переменной класса MapCurrent(new input)
    private MapCurrent inputAction;

    private bool isLook;
    private void OnEnable()
    {
        inputAction = new MapCurrent();//инициализируем карту input
        InputData = new InputData();

        if (inputAction != null)//проверим на null
        {
            //подпишем на event события нажатий и значения присвоим локальным переменым
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

            //запустим 
            inputAction.Enable();

            //запустим дублирующие события для иных классов
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
            Debug.LogError("Нет связи с классом MapCurrent");
        }
    }

    //если есть события WASD то создадим событие
    private void PerformedWASD(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>()!=null)
        {
            OnEventMove?.Invoke(true);
        }
    }
    //если событие WASD закончилось то создадим событие
    private void CanceledWASD(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() != null && isLook==false)
        {
            OnEventMove?.Invoke(false);
        }
    }

    //если есть события Look то создадим событие
    private void PerformedLook(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() != null)
        {
            isLook = true;
            OnEventMove?.Invoke(true);
        }
    }
    //если событие Look закончилось то создадим событие
    private void CanceledLook(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() != null)
        {
            isLook=false;
        }
    }


    void Update()
    {
        if (DebugLogOnOff)//для вывода в инспектор, временно
        {
            Debug.Log($"Движение Х = {InputData.Move.x}, Движение Y = {InputData.Move.y}");
            Debug.Log($"Мышь Х = {InputData.Mouse.x}, Мышь Y = {InputData.Mouse.y}");
            Debug.Log($"Выстрел = {InputData.Shoot}");
            Debug.Log($"Толчек = {InputData.Pull}");
            Debug.Log($"Режим = {InputData.Mode}");
        }
    }
}
