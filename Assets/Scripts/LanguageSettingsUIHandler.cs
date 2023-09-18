using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject button in languageButtonList)
        {
            string languageText = button.GetComponentInChildren<TMP_Text>().text;
            Button languageButton = button.GetComponent<Button>();
            languageButton.onClick.AddListener(() => ChangeLanguage(languageText));
        }
    }

    public void OpenLanguagePopUpWindow() 
    {
        languagePopUpWindow.SetActive(true);
    }

    private void ChangeLanguage(string language)
    {
        currentLanguage = language;
        languageSettingButton.text = currentLanguage;
        languagePopUpWindow.SetActive(false);
    }
}
