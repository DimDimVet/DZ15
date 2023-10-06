using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Главный справочник всех нужных объектов
/// </summary>
public abstract class RegistratorGo : MonoBehaviour
{
    private readonly static List<RegistratorConstruction> DataGO = new List<RegistratorConstruction>();
    /// <summary>
    /// Запишем в лист
    /// </summary>
    /// <param name="registrator"></param>
    public void SetData(RegistratorConstruction registrator)
    {
        DataGO.Add(registrator);
    }
    /// <summary>
    /// Получим лист
    /// </summary>
    /// <returns></returns>
    public List<RegistratorConstruction> GetData()
    {
        return DataGO;
    }
}
