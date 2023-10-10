using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;

//������� Rewarded
public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string androidAdID = "Rewarded_Android";
    [SerializeField] string iOSAdID = "Rewarded_iOS";
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
        print("������� ���������: " + placementId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print($"������ �������� �������: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print($"������ ������ �������: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("����� ������ �������: " + placementId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        print("���� �� �������: " + placementId);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            // ��� ��� ��� ���������� ������� ������.
            print("����� �������� ����� �������, � ������� ������ ������.");
        }
    }
    //��� ������, ��� ����� ����� ��, ��� � ����������. ����� ������� ��� �� �������� ��� ������ ������ ShowAd().
    //������������, �� ��� �������� �� �������� ��������, ��� �� ����� OnUnityAdsShowComplete() � ������ #46.
    //����� �� ����� �������� ���, ������� ����� ��������� ��������� ������ �� �������� �������.
    private void Update()
    {
        if (start)
        {
            ShowAd();
            start=!start;
        }
    }
}
