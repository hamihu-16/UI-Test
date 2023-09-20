using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGlowHandler : MonoBehaviour
{
    [SerializeField] private Image glowUI;
    [SerializeField] private string languageText;
    public event Action<GameObject> OnChangeLanguage;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => OnChangeLanguage?.Invoke(gameObject));
        //glowUI = GetComponentInChildren<Image>();
    }

    public void ChangeLanguage()
    {
        //OnChangeLanguage?.Invoke(gameObject);
    }

    public void onLanguageChanged(string currentLanguage)
    {
        if (languageText != currentLanguage)
        {
            glowUI.enabled = false;
        }
        else
        {
            glowUI.enabled = true;
        }
    }
}
