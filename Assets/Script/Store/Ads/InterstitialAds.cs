using UnityEngine;
using UnityEngine.Advertisements;
using static EventManager;

//Реклама Interstitial
public class InterstitialAds : AdsInitializer
{
    [SerializeField] string androidAdID = "Interstitial_Android";
    [SerializeField] string iOSAdID = "Interstitial_iOS";
    private string adID;

    private int adsCount = 20;
    private int tempCount;

    private void Start()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID : androidAdID;

    }

    private void OnEnable()
    {
        OnTrigerInterstitialAds += ShowAd;
        OnTrigerCount += ADSCount;
    }

    private void ADSCount()
    {
        tempCount++;
        if (tempCount >= adsCount)
        {
            ShowAd();
            tempCount = 0;
        }
    }

    public void ShowAd()
    {
        Advertisement.Load(adID, this);
        Advertisement.Show(adID, this);
    }

    public override void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
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
}
