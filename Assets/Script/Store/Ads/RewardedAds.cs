using UnityEngine;
using UnityEngine.Advertisements;
using static EventManager;

//–еклама Rewarded
public class RewardedAds : AdsInitializer
{
    [SerializeField] string androidAdID = "Rewarded_Android";
    [SerializeField] string iOSAdID = "Rewarded_iOS";
    private string adID;

    private void Start()
    {
        adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID : androidAdID;
    }

    private void OnEnable()
    {
        OnTrigerRewardedAds += ShowAd;
    }

    public void ShowAd()
    {
        Advertisement.Load(adID, this);
        Advertisement.Show(adID, this);
    }

    public override void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            // тут код дл€ добавлени€ бонусов игроку.
            print("ёнити завершил показ рекламы, и добавил бонусы игроку.");
        }
    }
    // ак видите, код почти такой же, как и предыдущий. ¬ызов рекламы так же создаЄтс€ при помощи метода ShowAd().
    //≈динственное, на что хотелось бы обратить внимание, это на метод OnUnityAdsShowComplete() в строке #46.
    //«десь мы можем дописать код, который будет добавл€ть различные бонусы за просмотр рекламы.
}
