using UnityEngine;
using UnityEngine.Advertisements;

//������� Banner
public class BannerAd : MonoBehaviour
{
    [SerializeField] BannerPosition bannerPosition;

    [SerializeField] string androidAdID = "Banner_Android";
    [SerializeField] string iOSAdID = "Banner_iOS";
    private string adID;

    public bool start;

    //private void Awake()
    //{
        
    //}

    private void Start()
    {
        print("BannerAd start");
        adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID : androidAdID;
        Advertisement.Banner.SetPosition(bannerPosition);
    }

    public void ShowAd()
    {
        BannerLoadOptions optionsLoad = new BannerLoadOptions { loadCallback = OnBannerLoaded, errorCallback = OnBannerError };
        Advertisement.Banner.Load(adID, optionsLoad);

        BannerOptions optionsShow = new BannerOptions { clickCallback = OnBannerClicked, hideCallback = OnBannerHidden, showCallback = OnBannerShow };
        Advertisement.Banner.Show(adID, optionsShow);
    }

    private void OnBannerLoaded()
    {
        print("������ ��������");
    }

    private void OnBannerError(string message)
    {
        print($"������ �������� �������: {message}");
    }

    private void OnBannerClicked()
    {
        print("������ ��� �������");
    }

    private void OnBannerHidden()
    {
        print("������ ��� �����");
    }

    private void OnBannerShow()
    {
        print("������ ��� �������");
    }
    //��� ������, ������ ��� ������� ��� �� ����� ����� �� ����������,
    //�� ����������� ����� ���������� bannerPosition, ������� �������� �� ������� ������������ ��������.
    //��� ������� ����� ������� � ������� ���� Inspector. ����� ��� ��, ��� � � ���� ������ ��������,
    //������������ ����� ShowAd() ��� ������ �������.
    private void Update()
    {
        if (start)
        {
            ShowAd();
            start=!start;
        }
    }
}
