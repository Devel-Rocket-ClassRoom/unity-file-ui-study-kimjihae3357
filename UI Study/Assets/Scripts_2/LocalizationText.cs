using System;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]

public class LocalizationText : MonoBehaviour
{
#if UNITY_EDITOR
    public Languages editorLang;

#endif
    public string id;
    public TextMeshProUGUI text;

    private object[] formatArgs = new object[0];



    private void OnEnable()
    {
        if (Application.isPlaying)
        {
            Variables.OnLanguageChanged += OnChangeLanguage;
            OnChangedId();
        }
#if UNITY_EDITOR
        else
        {
            OnChangeLanguage(editorLang);
        }
#endif

    }
    private void OnDisable()
    {
        Variables.OnLanguageChanged -= OnChangeLanguage;
    }

    private void OnValidate()
    {
#if UNITY_EDITOR
        OnChangeLanguage(editorLang);

#endif

    }

    public void OnChangedId()
    {
        string localized = DataTableManager.StringTable.Get(id);
        text.text = string.Format(localized, formatArgs);
    }

    public void SetFormat(string newId, params object[] args)
    {
        id = newId;
        formatArgs = args;
        OnChangedId();
    }

    private void OnChangeLanguage()
    {
        string localized = DataTableManager.StringTable.Get(id);
        text.text = string.Format(localized, formatArgs);
    }
#if UNITY_EDITOR

    private void OnChangeLanguage(Languages lang)
    {
        var stringTable = DataTableManager.GetStringTable(lang);
        string localized = stringTable.Get(id);
        text.text = string.Format(localized, formatArgs);
    }

#endif
}