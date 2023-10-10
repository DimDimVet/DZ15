using System;

public class EventManager
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

    //запрос листа объекта по hash
    public static Func<int,RegistratorConstruction> OnGetObjectHash;//запросим из пространства лист
    public static RegistratorConstruction GetObjectHash(int hash)
    {
        return (RegistratorConstruction)OnGetObjectHash?.Invoke(hash);//запросим из пространства лист
    }

    //передача урона по hash
    public static Action<int, int> OnGetDamageHash;//запросим из пространства лист
    public static void GetDamageHash(int hash, int damage)
    {
        OnGetDamageHash?.Invoke(hash, damage);//запросим из пространства лист
    }

    //запрос листа NetPhoton
    public static Func<RegistratorConstruction> OnGetNetworkManager;//запросим из пространства лист
    public static RegistratorConstruction GetNetworkManager()
    {
        return (RegistratorConstruction)OnGetNetworkManager?.Invoke();//запросим из пространства лист
    }

    //тригер счетчика
    public delegate void Trigers();
    public static event Trigers OnTrigerCount;//запросим из пространства лист
    public static void TrigerCount()
    {
        OnTrigerCount?.Invoke();//запросим из пространства лист
    }

    //запрос листа Inventory
    public static Func<RegistratorConstruction> OnGetInventory;//запросим из пространства лист
    public static RegistratorConstruction GetInventory()
    {
        return (RegistratorConstruction)OnGetInventory?.Invoke();//запросим из пространства лист
    }

    //тригер рекламы RewardedAds
    public delegate void TrigerRewardedAds();
    public static event TrigerRewardedAds OnTrigerRewardedAds;//запросим из пространства лист
    public static void RewardedAds()
    {
        OnTrigerRewardedAds?.Invoke();//запросим из пространства лист
    }

    //тригер рекламы InterstitialAds
    public delegate void TrigerInterstitialAds();
    public static event TrigerInterstitialAds OnTrigerInterstitialAds;//запросим из пространства лист
    public static void InterstitialAds()
    {
        OnTrigerInterstitialAds?.Invoke();//запросим из пространства лист
    }

    //тригер рекламы BannerAd
    public delegate void TrigerBannerAd(bool _isStatus);
    public static event TrigerBannerAd OnTrigerBannerAd;//запросим из пространства лист
    public static void BannerAd(bool _isStatus)
    {
        OnTrigerBannerAd?.Invoke(_isStatus);//запросим из пространства лист
    }

}
