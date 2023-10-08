using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class CountText : MonoBehaviour
{
    [SerializeField] private Text textHealt;
    [SerializeField] private Text textCountBull;

    private RegistratorConstruction rezultPlayer;
    private bool isRun=false;
    private void Awake()
    {
        OnTrigerCount += UpDateCount;
    }

    private void OnDisable()
    {
        OnTrigerCount -= UpDateCount;
    }

    private void OnDestroy()
    {
        OnTrigerCount += UpDateCount;
    }

    private void UpDateCount()
    {
        if (rezultPlayer.Healt != null)
        {
            textHealt.text = $"{rezultPlayer.Healt.HealtCount}";
        }

        if (rezultPlayer.ShootPlayer != null)
        {
            textCountBull.text = $"{rezultPlayer.ShootPlayer.CountBull}";
        }
    }

    private void FixedUpdate()
    {
        if (!isRun)
        {
            rezultPlayer = GetPlayer();
            if (rezultPlayer.Healt != null && rezultPlayer.ShootPlayer != null)
            {
                textHealt.text = $"{rezultPlayer.Healt.HealtCount}";
                textCountBull.text = $"{rezultPlayer.ShootPlayer.CountBull}";
                isRun = true;
            }
        }
    }
}

