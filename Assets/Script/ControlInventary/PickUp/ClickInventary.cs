using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickInventary : MonoBehaviour
{
    private Button button;
    [SerializeField]

    private void Start()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener();
    }
}
