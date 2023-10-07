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

    public void MoveActiv()
    {
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
