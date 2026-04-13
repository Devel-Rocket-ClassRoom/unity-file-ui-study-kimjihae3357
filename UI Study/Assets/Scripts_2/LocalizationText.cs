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
            //OnChangedId();
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
        //OnChangedId();

#endif

    }

    private void OnChangedId()
    {
        text.text = DataTableManager.StringTable.Get(id);
    }

    private void OnChangeLanguage()
    {
        text.text = DataTableManager.StringTable.Get(id);
    }
#if UNITY_EDITOR

    private void OnChangeLanguage(Languages lang)
    {
        var stringTable = DataTableManager.GetStringTable(lang);
        text.text = stringTable.Get(id);
    }

    [ContextMenu("한국어")] //언어 바꾸기
    private void ChangeKorean()
    {
        //DataTableManager.StringTable.
    }
    [ContextMenu("영어")]
    private void ChangEnglish()
    {

    }
    [ContextMenu("일본어")]
    private void ChangeJapanese()
    {

    }

#endif
}