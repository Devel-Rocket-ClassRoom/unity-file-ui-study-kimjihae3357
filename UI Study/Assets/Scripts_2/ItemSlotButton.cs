using UnityEngine;
using UnityEngine.UI;

public class ItemSlotButton : MonoBehaviour
{
    public string itemId;
    public Image icon;
    public LocalizationText textName;
    public ItemDetailUI itemInfo;

    public void OnValidate()
    {
        OnChangeItemId();
    }

    public void  OnChangeItemId()
    {
        ItemData data = DataTableManager.ItemTable.Get(itemId);
        if (data != null )
        {
            icon.sprite = data.SpriteIcon;
            textName.id = data.Name;
            textName.OnChangedId();
        }

    }
    public void OnClick()
    {
        itemInfo.SetItemData(itemId);
    }
}
