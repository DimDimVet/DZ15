using Photon.Pun;
using UnityEngine;
using Zenject;

public class UserInput : MonoBehaviour
{
    //���������� � ������, ����� ������ ����� �������� ���������� MapCurrent � ������� Move � Camera
    
    public InputData InputData;//��������� ������
    public bool DebugLogOnOff;//��� ������
    //��������� ����� MapCurrent(new input)
    private MapCurrent inputAction;

    void Start()
    {

        inputAction = new MapCurrent();//�������������� ����� input
        InputData=new InputData();

        if (inputAction!=null)//�������� �� null
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
        }
        else
        {
            Debug.LogError("��� ����� � ������� MapCurrent");
        }
        
    }

    void Update()
    {
        if (DebugLogOnOff)
        {
            Debug.Log($"�������� � = {InputData.Move.x}, �������� Y = {InputData.Move.y}");
            Debug.Log($"���� � = {InputData.Mouse.x}, ���� Y = {InputData.Mouse.y}");
            Debug.Log($"������� = {InputData.Shoot}");
            Debug.Log($"������ = {InputData.Pull}");
            Debug.Log($"����� = {InputData.Mode}");
        }
    }
}
