using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailUI : MonoBehaviour
{

    public Image image;
    public LocalizationText textName;
    public LocalizationText textDesc;


    private void OnEnable()
    {
        SetEmpty();
    }

    public void SetEmpty()
    {
        image.sprite = null;
        textName.id = string.Empty;
        textDesc.id = string.Empty;

        //textName.OnChangedId();
        //textDesc.OnChangedId();

        textName.text.text = string.Empty;
        textDesc.text.text = string.Empty;
        
    }

    public  void SetCharacterData(string characterId)
    {
        CharacterData data =  DataTableManager.CharacterTable.Get(characterId);
        SetCharacterData(data);
    }

    public void  SetCharacterData(CharacterData data)
    {
        image.sprite = data.SpriteImage;
        textName.id = data.Name;
        textDesc.id = data.Desc;

        textName.OnChangedId();
        textDesc.OnChangedId();
    }

    
}
