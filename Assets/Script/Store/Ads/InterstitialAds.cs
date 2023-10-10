using UnityEngine;
using UnityEngine.Advertisements;

//Реклама Interstitial
public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string androidAdID = "Interstitial_Android";
    [SerializeField] string iOSAdID = "Interstitial_iOS";
    private string adID;

    public bool start;

    private void Start()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID : androidAdID;
    }

    public void ShowAd()
    {
        Advertisement.Load(adID, this);
        Advertisement.Show(adID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        print("Реклама загружена: " + placementId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print($"Ошибка загрузки рекламы: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print($"Ошибка показа рекламы: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("Старт показа реклама: " + placementId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        print("клик по рекламе: " + placementId);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        print("Юнити завершил показ рекламы.");
    }
    //Разбирать данный скрипт мы не будем, поскольку он очень похож на предыдущий.То-есть, здесь так же создаём
    //переменные для Android и iOS, и определяем устройство пользователя.Здесь так же имеется 6 обработчиков событий,
    //которые в консоль заносят различные уведомления.

    //Важно! Единственное на что хотелось бы обратить внимание, это на метод ShowAd(),
    //который сначала с помощью метода Load() подгружает рекламу,
    //а потом с помощью метода Show() отображает её на экране для пользователя.Именно этот метод и нужно вызывать тогда,
    //когда вам необходимо отобразить рекламу на игровой сцене.
    //Например вызов данного метода можно произвести сразу после нажатия на определённую кнопку.

    private void Update()
    {
        if (start)
        {
            ShowAd();
            start=!start;
        }
    }
}
