using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.InputSystem;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string androidGameID = "5440097";
    [SerializeField] string iOSGameID = "5440096";
    [SerializeField] bool testMode = true;
    private string gameID;

    private void Awake()
    {
        gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSGameID : androidGameID;
        Advertisement.Initialize(gameID, testMode, this);
    }


    public void OnInitializationComplete()
    {
        print("Инициализация прошла успешно.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print($"Ошибка инициализации: {error.ToString()} - {message}");
    }

//В строке #2 мы подключаем библиотеку UnityEngine.Advertisements, так как работаем с рекламой. А чуть ниже наследуем итерфейс IUnityAdsInitializationListener.
//В строках #6-7 мы создали переменные, в которые необходимо занести ID нашей игры для андройда и айфона.
//В строке #8 мы укажем, что реклама должна отображаться в тестовом режиме. При завершении разработки игры, необходимо изменить данное значение на false.
//В методе Awake() мы проверяем устройство игрока, если это айфон, то в переменную gameID заносим ID айфона, иначе в данную переменную заносим ID андройда.
//Ну а в строке #14, с помощью метода Initialize() мы проводим подключение к рекламной сети. Если подключение прошло успешно, то вызывается метод OnInitializationComplete(), а если произошла ошибка, то вызывается метод OnInitializationFailed().
}
