using System.IO;
using UnityEngine;

public class SaveFile : MonoBehaviour
{
    private int saveSlot = 0;
    private string saveDir;

    private void Start()
    {
        saveDir = Path.Combine(Application.persistentDataPath, "SaveData");
        if (!Directory.Exists(saveDir))
        {
            Directory.CreateDirectory(saveDir);
        }
    }

    private void Update()
    {
        if (saveSlot < 0)
        {
            saveSlot = 0;
        }

        string saveFilePath = Path.Combine(saveDir, $"save{saveSlot + 1}.txt");
        string[] saveFiles = Directory.GetFiles(saveDir);

        if (Input.GetKeyDown(KeyCode.S))
        {
            File.WriteAllText(saveFilePath, "save text");
            Debug.Log($"Saved to {saveFilePath}");
            saveSlot++;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            File.Delete(saveFilePath);
            Debug.Log($"Deleted {saveFilePath}");
            saveSlot--;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            saveSlot = 1;
            string copyFilePath = Path.Combine(saveDir, $"save{saveSlot}_backup.txt");
            File.Copy(saveFilePath, copyFilePath);
            Debug.Log($"{Path.GetFileName(saveFilePath)} -> {Path.GetFileName(copyFilePath)} 복사 완료");
            saveSlot = saveFiles.Length - 1;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            for (int i = 0; i < saveFiles.Length; i++)
            {
                Debug.Log($"{Path.GetFileName(saveFiles[i])} ({Path.GetExtension(saveFiles[i])})");
            }
        }
    }
}