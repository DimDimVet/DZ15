using System;
using System.Collections.Generic;

public class EventManager /*: MonoBehaviour*/
{
    //������ ����� Camera
    public static Func<RegistratorConstruction> OnGetCamera;//�������� �� ������������ ����
    public static RegistratorConstruction GetCamera()
    {
        return (RegistratorConstruction)OnGetCamera?.Invoke();//�������� �� ������������ ����
    }

    //������ ����� Player
    public static Func<RegistratorConstruction> OnGetPlayer;//�������� �� ������������ ����
    public static RegistratorConstruction GetPlayer()
    {
        return (RegistratorConstruction)OnGetPlayer?.Invoke();//�������� �� ������������ ����
    }
}
