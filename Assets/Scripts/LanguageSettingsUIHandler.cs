using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettingsUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text languageSettingButton;
    [SerializeField] private GameObject languagePopUpWindow;
    [SerializeField] private List<GameObject> languageButtonList;
    [SerializeField] private string currentLanguage = "English";

    public static event Action<string> OnLanguageChanged;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject button in languageButtonList)
        {
            string languageText = button.GetComponentInChildren<TMP_Text>().text;
            Button languageButton = button.GetComponent<Button>();
            languageButton.onClick.AddListener(() => ChangeLanguage(button.gameObject, languageText));

            if (languageText == currentLanguage)
            {
                button.GetComponentInChildren<Image>().enabled = true;
            }
        }

    }

    public void OpenLanguagePopUpWindow() 
    {
        languagePopUpWindow.SetActive(true);
        foreach (GameObject button in languageButtonList)
        {
            string languageText = button.GetComponentInChildren<TMP_Text>().text;
            if (languageText == currentLanguage)
            {
                button.GetComponentsInChildren<Image>()[1].enabled = true;
            }
            else
            {
                button.GetComponentsInChildren<Image>()[1].enabled = false;
            }
        }
    }

    public void CloseLanguagePopUpWindow()
    {
        languagePopUpWindow.SetActive(false);
    }

    private void ChangeLanguage(GameObject clickedButton, string languageText)
    {
        currentLanguage = languageText;
        languageSettingButton.text = languageText;
        CloseLanguagePopUpWindow();
    }
}
