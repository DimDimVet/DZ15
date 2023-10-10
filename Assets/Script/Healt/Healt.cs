using UnityEngine;
using static EventManager;

public class Healt : MonoBehaviour
{
    [SerializeField] private HealtSetting settingsData;

    private int healtCount = 0;
    public int HealtCount { get { return healtCount; } set { healtCount = value; } }

    private int damage = 0;
    public int Damage { get { return damage; } set { damage = value; } }

    private bool dead = false;
    public bool Dead { get { return dead; } set { dead = value; } }

    private int thisHash;

    private void Awake()
    {
        thisHash=gameObject.GetHashCode();

        if (settingsData.Healt != 0)
        {
            HealtCount = settingsData.Healt;
        }
    }

    private void OnEnable()
    {
        OnGetDamageHash += HealtContoll;
    }

    private void OnDisable()
    {
        OnGetDamageHash -= HealtContoll;
    }

    private void OnDestroy()
    {
        OnGetDamageHash -= HealtContoll;
    }

    public void HealtContoll(int hash,int damage)
    {
        if (thisHash == hash)
        {
            HealtCount -= damage;
            TrigerCount();
            if (HealtCount <= 0)
            {
                Dead = true;
                DestoyGO();
            }
        }
    }

    public void DestoyGO()
    {
        RewardedAds();
        RegistratorConstruction rezult =GetNetworkManager();
        if (rezult.NetworkManager!=null)//объект созданный через фотон, убиваем через фотон
        {
            rezult.NetworkManager.DestroyThisGO(this.gameObject);
        }
    }
}
