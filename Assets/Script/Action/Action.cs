using UnityEngine;
using static EventManager;

public class Action : MonoBehaviour
{
    private RegistratorConstruction rezultInput;
    public RegistratorConstruction RezultInput { get { return rezultInput; } }

    private bool isRun;
    public bool IsRun { get { return isRun; } }

    public delegate void OnGetConnectEvent();
    private void Start()
    {
        OnGetConnectEvent onGetConnectEvent = new OnGetConnectEvent(GetConnectEvent);
    }
    private void GetConnectEvent()//�������� ���������� �� ���������� ������ �� �����
    {
        if (!isRun)//���� ����� ���������� �� ������ false
        {
            rezultInput = GetPlayer();//�������� ������ �� �����

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

    public void MoveActiv()
    {
    }
    private void FixedUpdate()
    {
        if (!isRun)//���� ��� ����������, �������� ���������� ����
        {
            GetConnectEvent();
        }
        else
        {
            MoveActiv();
        }
    }
}
