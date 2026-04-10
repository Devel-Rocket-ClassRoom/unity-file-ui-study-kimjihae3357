using System.IO;
using UnityEngine;

public class SaveFileManager : MonoBehaviour
{
    string folder;

    int count = 0;
   
    void Start()
    {
        

    }

    void Update()
    {
        //폴더 생성
        if (Input.GetKeyDown(KeyCode.Q))
        {
            folder = Application.persistentDataPath + "/SaveData";
            Directory.CreateDirectory(folder);
            Debug.Log("폴더 생성 위치:" + folder);
        }

        // 파일 생성
        if (Input.GetKeyDown(KeyCode.W))
        {
            string path = folder + "/save" + count + ".txt";
            File.WriteAllText(path, "세이브 파일");
            Debug.Log("세이브파일 추가");
            count++;
        }

        // 파일 목록 출력
        if (Input.GetKeyDown(KeyCode.E))
        {
            string[] filesList = Directory.GetFiles(folder);
            Debug.Log(filesList);

        }
    }
}
