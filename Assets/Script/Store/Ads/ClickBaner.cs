using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static EventManager;

public class ClickBaner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text; 
    private Button button;
    private bool isTriger=true;
    private string varOn = "Хочу баннер", varOff = "Не хочу баннер";

    void Start()
    {
        button = GetComponent<Button>();
        _text.text = varOn;
        button.onClick.AddListener(RezultClick);
    }

    private void RezultClick()
    {
        if (isTriger)
        {
            BannerAd(isTriger);
            _text.text = varOff;
            isTriger = !isTriger;
        }
        else
        {
            BannerAd(isTriger);
            _text.text = varOn;
            isTriger = !isTriger;
        }
        
    }
}
