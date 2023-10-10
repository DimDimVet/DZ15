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
        print("������������� ������ �������.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print($"������ �������������: {error.ToString()} - {message}");
    }

//� ������ #2 �� ���������� ���������� UnityEngine.Advertisements, ��� ��� �������� � ��������. � ���� ���� ��������� �������� IUnityAdsInitializationListener.
//� ������� #6-7 �� ������� ����������, � ������� ���������� ������� ID ����� ���� ��� �������� � ������.
//� ������ #8 �� ������, ��� ������� ������ ������������ � �������� ������. ��� ���������� ���������� ����, ���������� �������� ������ �������� �� false.
//� ������ Awake() �� ��������� ���������� ������, ���� ��� �����, �� � ���������� gameID ������� ID ������, ����� � ������ ���������� ������� ID ��������.
//�� � � ������ #14, � ������� ������ Initialize() �� �������� ����������� � ��������� ����. ���� ����������� ������ �������, �� ���������� ����� OnInitializationComplete(), � ���� ��������� ������, �� ���������� ����� OnInitializationFailed().
}
