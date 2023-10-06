using UnityEngine;

public  class UserInput : MonoBehaviour
{
    private InputData inputData;//Передадим данные
    public InputData InputData { get { return inputData; } set { inputData = value; } }

    private bool isMove;//разрешение на событие движения
    public bool IsMove { get { return isMove; } set { isMove = value; } }

    public bool DebugLogOnOff;//для тестов //для вывода в инспектор, временно
    private MapCurrent inputAction;//Кэш переменной класса MapCurrent(new input)

    private void OnEnable()
    {
        inputAction = new MapCurrent();//инициализируем карту input
        inputData = new InputData();

        if (inputAction != null)//проверим на null
        {
            //подпишем на event события нажатий и значения присвоим локальным переменым
            inputAction.UIMap.WASD.performed += context => { inputData.Move = context.ReadValue<Vector2>();
                if (context.ReadValue<Vector2>() != null) { isMove = true; } else { isMove = false; }
            };
            inputAction.UIMap.WASD.started += context => { inputData.Move = context.ReadValue<Vector2>();
                if (context.ReadValue<Vector2>() != null) { isMove = true; } else { isMove = false; }
            };
            inputAction.UIMap.WASD.canceled += context => { inputData.Move = context.ReadValue<Vector2>();
                if (context.ReadValue<Vector2>() != null) { isMove = false; } else { isMove = true; }
            };

            inputAction.Map.WASD.performed += context => { inputData.Move = context.ReadValue<Vector2>();
                if (context.ReadValue<Vector2>() != null) { isMove = true; } else { isMove = false; }
            };
            inputAction.Map.WASD.started += context => { inputData.Move = context.ReadValue<Vector2>();
                if (context.ReadValue<Vector2>() != null) { isMove = true; } else { isMove = false; }
            };
            inputAction.Map.WASD.canceled += context => { inputData.Move = context.ReadValue<Vector2>();
                if (context.ReadValue<Vector2>() != null) { isMove = false; } else { isMove = true; }
            };

            inputAction.Map.Look.performed += context => { inputData.Mouse = context.ReadValue<Vector2>();
                if (context.ReadValue<Vector2>() != null) { isMove = true; } else { isMove = false; }
            };
            inputAction.Map.Look.started += context => { inputData.Mouse = context.ReadValue<Vector2>();
                if (context.ReadValue<Vector2>() != null) { isMove = true; } else { isMove = false; }
            };
            inputAction.Map.Look.canceled += context => { inputData.Mouse = context.ReadValue<Vector2>();
                if (context.ReadValue<Vector2>() != null) { isMove = false; } else { isMove = true; }
            };

            inputAction.Map.Shoot.performed += context => { inputData.Shoot = context.ReadValue<float>(); };
            inputAction.Map.Shoot.started += context => { inputData.Shoot = context.ReadValue<float>(); };
            inputAction.Map.Shoot.canceled += context => { inputData.Shoot = context.ReadValue<float>(); };

            inputAction.Map.Pull.performed += context => { inputData.Pull = context.ReadValue<float>(); };
            inputAction.Map.Pull.started += context => { inputData.Pull = context.ReadValue<float>(); };
            inputAction.Map.Pull.canceled += context => { inputData.Pull = context.ReadValue<float>(); };

            inputAction.Map.ModePlayer.performed += context => { inputData.Mode = context.ReadValue<float>(); };
            inputAction.Map.ModePlayer.started += context => { inputData.Mode = context.ReadValue<float>(); };
            inputAction.Map.ModePlayer.canceled += context => { inputData.Mode = context.ReadValue<float>(); };

            //запустим 
            inputAction.Enable();
        }
        else
        {
            Debug.LogError("Нет связи с классом MapCurrent");
        }
    }

    void Update()
    {
        Debug.Log($"{IsMove} -{inputData.Move}");
        if (DebugLogOnOff)//для вывода в инспектор, временно
        {
            Debug.Log($"Движение Х = {inputData.Move.x}, Движение Y = {inputData.Move.y}");
            Debug.Log($"Мышь Х = {inputData.Mouse.x}, Мышь Y = {inputData.Mouse.y}");
            Debug.Log($"Выстрел = {inputData.Shoot}");
            Debug.Log($"Толчек = {inputData.Pull}");
            Debug.Log($"Режим = {inputData.Mode}");
        }
    }
}
