using System.IO;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class SaveFileManager : MonoBehaviour
{
    string folder;

    int count = 0;

    void Start()
    {
        // 폴더 생성
        folder = Application.persistentDataPath + "/SaveData";
        Directory.CreateDirectory(folder);
        Debug.Log("폴더 생성 위치:" + folder);
    }

    void Update()
    {

        // 파일 생성
        if (Input.GetKeyDown(KeyCode.Q))
        {
            string path = folder + "/save" + count + ".txt";
            File.WriteAllText(path, "세이브 파일");
            Debug.Log("세이브파일 추가");
            count++;
        }

        // 파일 목록 출력
        if (Input.GetKeyDown(KeyCode.W))
        {
            string[] filesList = Directory.GetFiles(folder);

            foreach (string file in filesList)
            {
                Debug.Log(file);
            }

        }

        // 파일 복사
        if (Input.GetKeyDown(KeyCode.E))
        {
            string original = folder + "/save0.txt";
            string copy = folder + "/save0_backup.txt";

            if (File.Exists(original))
            {
                File.Copy(original, copy, true);
                Debug.Log($"{copy} 복사 완료");
            }
            else
            {
                Debug.Log("복사할 파일 없음");
            }
        }

        // 파일 삭제
        if (Input.GetKeyDown(KeyCode.R))
        {
            string file = folder + "/save0.txt";

            if (File.Exists(file))
            {
                File.Delete(file);
                Debug.Log($"{file} 삭제 완료");
            }
            else
            {
                Debug.Log("삭제할 파일 없음");
            }

        }
        // 파일 리스트 출력
        if (Input.GetKeyDown(KeyCode.A))
        {
            PrintFileList("세이브 파일 목록");
        }
    }
    void PrintFileList(string title)
    {
        Debug.Log("=== " + title + " ===");

        if (Directory.Exists(folder))
        {
            string[] files = Directory.GetFiles(folder); //폴더 내 파일 목록 반환

            foreach (string file in files)
            {
                string name = Path.GetFileName(file); //파일명 추출
                string ext = Path.GetExtension(file); //확장자 추출

                Debug.Log("- " + name + " (" + ext + ")");
            }
        }
    }
}


