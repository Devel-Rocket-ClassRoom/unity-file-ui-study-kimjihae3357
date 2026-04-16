using UnityEngine;
using SaveDataVC = SaveDataV1;

public class SaveLoadTest1 : MonoBehaviour
{
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveLoadManager.Data = new SaveDataV3();
            SaveLoadManager.Data.Name = "TEST1234";
            SaveLoadManager.Data.Gold = 4321;
            SaveLoadManager.Data.itemList.Add("Item1");
            SaveLoadManager.Data.itemList.Add("Item2");
            SaveLoadManager.Data.itemList.Add("Item3");
            SaveLoadManager.Data.itemList.Add("Item4");
            SaveLoadManager.Save();
            Debug.Log("세이브됨");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           if (SaveLoadManager.Load())
            {
                Debug.Log(SaveLoadManager.Data.Name);
                Debug.Log(SaveLoadManager.Data.Gold);

                foreach (var itemId in SaveLoadManager.Data.itemList)
                {
                    Debug.Log(DataTableManager.ItemTable.Get(itemId).Name);
                }
            }
            else
            {
                Debug.Log("세이브 파일 없음");
            }
        }
    }
}
