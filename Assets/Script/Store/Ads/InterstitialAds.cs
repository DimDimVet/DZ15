using UnityEngine;
using UnityEngine.Advertisements;

//������� Interstitial
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
        print("����� �������� ����� �������.");
    }
    //��������� ������ ������ �� �� �����, ��������� �� ����� ����� �� ����������.��-����, ����� ��� �� ������
    //���������� ��� Android � iOS, � ���������� ���������� ������������.����� ��� �� ������� 6 ������������ �������,
    //������� � ������� ������� ��������� �����������.

    //�����! ������������ �� ��� �������� �� �������� ��������, ��� �� ����� ShowAd(),
    //������� ������� � ������� ������ Load() ���������� �������,
    //� ����� � ������� ������ Show() ���������� � �� ������ ��� ������������.������ ���� ����� � ����� �������� �����,
    //����� ��� ���������� ���������� ������� �� ������� �����.
    //�������� ����� ������� ������ ����� ���������� ����� ����� ������� �� ����������� ������.

    private void Update()
    {
        if (start)
        {
            ShowAd();
            start=!start;
        }
    }
}
