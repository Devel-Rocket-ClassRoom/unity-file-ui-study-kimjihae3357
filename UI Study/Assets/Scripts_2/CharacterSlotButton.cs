using UnityEngine;
using UnityEngine.UI;

public class CharacterSlotButton : MonoBehaviour
{
    public string characterId;
    public Image icon;
    public LocalizationText textName;
    public CharacterDetailUI characterInfo;

    public void OnValidate()
    {
        OnChangeCharacterId();
    }

    public void OnChangeCharacterId()
    {
        CharacterData data = DataTableManager.CharacterTable.Get(characterId);
        if (data != null )
        {
            icon.sprite = data.SpriteIcon;
            textName.id = data.Name;
            textName.OnChangedId();
        }

    }
    public void OnClick()
    {
        characterInfo.SetCharacterData(characterId);
    }
}
