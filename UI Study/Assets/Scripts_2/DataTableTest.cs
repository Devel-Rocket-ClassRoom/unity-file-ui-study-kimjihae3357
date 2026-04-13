using UnityEngine;

public class DataTableTest : MonoBehaviour
{
    public string NameStringTableKr = "StringTableKr";
    public string NameStringTableEn = "StringTableEn";
    public string NameStringTableJp = "StringTableJp";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Variables.Language = Languages.Korean;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Variables.Language = Languages.Emglish;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Variables.Language = Languages.Japanese;
        }
    }
    public void OnClickStringTableKr()
    {
        Debug.Log(DataTableManager.StringTable.Get("You Die"));
    }

    public void OnClickStringTableEn()
    {
        var stringTable = new StringTable();
        stringTable.Load(NameStringTableEn);
        Debug.Log(stringTable.Get("Bye"));

    }

    public void OnClickStringTableJp()
    {
        var stringTable = new StringTable();
        stringTable.Load(NameStringTableJp);
        Debug.Log(stringTable.Get("Hello"));

    }
}