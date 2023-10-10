using UnityEngine;
using UnityEngine.Advertisements;
using static EventManager;

//Реклама Banner
public class BannerAd : AdsInitializer
{
    [SerializeField] BannerPosition bannerPosition;

    [SerializeField] string androidAdID = "Banner_Android";
    [SerializeField] string iOSAdID = "Banner_iOS";
    private string adID;

    private void Start()
    {
        print("BannerAd start");
        adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID : androidAdID;
        Advertisement.Banner.SetPosition(bannerPosition);
    }

    private void OnEnable()
    {
        OnTrigerBannerAd += SwithBanner;
    }

    private void SwithBanner(bool _isStatus)
    {
        if (_isStatus)
        {
            ShowAd(_isStatus);
        }
        else
        {
            CloseAd(_isStatus);
        }
    }

    private void ShowAd(bool _isStatus)
    {
        BannerLoadOptions optionsLoad = new BannerLoadOptions { loadCallback = OnBannerLoaded, errorCallback = OnBannerError };
        Advertisement.Banner.Load(adID, optionsLoad);

        BannerOptions optionsShow = new BannerOptions { clickCallback = OnBannerClicked, hideCallback = OnBannerHidden, showCallback = OnBannerShow };
        Advertisement.Banner.Show(adID, optionsShow);
    }

    private void CloseAd(bool _isStatus)
    {
        Advertisement.Banner.Hide(_isStatus);
    }

    private void OnBannerLoaded()
    {
        print("Баннер загружен");
    }

    private void OnBannerError(string message)
    {
        print($"Ошибка загрузки баннера: {message}");
    }

    private void OnBannerClicked()
    {
        print("Баннер был кликнут");
    }

    private void OnBannerHidden()
    {
        print("Баннер был скрыт");
    }

    private void OnBannerShow()
    {
        print("Баннер был показан");
    }
    //Как видите, данный тип рекламы так же очень похож на предыдущие,
    //за исключением новой переменной bannerPosition, которая отвечает за позицию расположения баннеров.
    //Эту позиции можно указать с помощью окна Inspector. Здесь так же, как и в двух других скриптах,
    //присутствует метод ShowAd() для вызова рекламы.
}
