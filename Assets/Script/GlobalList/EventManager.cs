using System;
using System.Collections.Generic;

public class EventManager /*: MonoBehaviour*/
{
    //запрос листа Camera
    public static Func<RegistratorConstruction> OnGetCamera;//запросим из пространства лист
    public static RegistratorConstruction GetCamera()
    {
        return (RegistratorConstruction)OnGetCamera?.Invoke();//запросим из пространства лист
    }

    //запрос листа Player
    public static Func<RegistratorConstruction> OnGetPlayer;//запросим из пространства лист
    public static RegistratorConstruction GetPlayer()
    {
        return (RegistratorConstruction)OnGetPlayer?.Invoke();//запросим из пространства лист
    }
}
