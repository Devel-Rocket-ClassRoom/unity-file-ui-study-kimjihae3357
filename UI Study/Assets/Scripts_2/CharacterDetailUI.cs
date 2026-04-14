using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailUI : MonoBehaviour
{

    public Image image;
    public LocalizationText textName;
    public LocalizationText textJob;
    public LocalizationText textAttack;
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
        textAttack.id = string.Empty;
        textJob.id = string.Empty;

        //textName.OnChangedId();
        //textDesc.OnChangedId();

        textName.text.text = string.Empty;
        textDesc.text.text = string.Empty;
        textAttack.text.text = string.Empty;
        textJob.text.text = string.Empty;
        
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

        textAttack.SetFormat("AttackText", data.Attack);

        string jobName = DataTableManager.StringTable.Get(data.Job);
        textJob.SetFormat("JobText", jobName);
    }

    
}
