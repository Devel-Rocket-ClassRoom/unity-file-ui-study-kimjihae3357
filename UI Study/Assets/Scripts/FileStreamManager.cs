using UnityEngine;
using System.IO;

public class FileStreamManager : MonoBehaviour
{
    string path;
    string text;

    void Start()
    {
        path = Application.persistentDataPath + "/secret.txt";
        text = "Hello Unity World";

        File.WriteAllText(path, text);
        Debug.Log($"{path} 생성완료");
        Debug.Log($"원본: {text}");
    }

    void Update()
    {
        // 암호화
        if (Input.GetKeyDown(KeyCode.Q))
        {
            string encryptedPath = Application.persistentDataPath + "/encrypted.dat";

            using (FileStream inputStream = new FileStream(path, FileMode.Open))
            using (FileStream outputStream = new FileStream(encryptedPath, FileMode.Create))
            {
                int key = 0xAB; //암호화에 사용할 키 값 (16진수 숫자)
                int data;


                while ((data = inputStream.ReadByte()) != -1)
                {
                    int encryptedByte = data ^ key;
                    outputStream.WriteByte((byte)encryptedByte);
                }
            }
            FileInfo fileInfo = new FileInfo(encryptedPath);
            Debug.Log($"{encryptedPath} 암호화 완료 (파일 크기: {fileInfo.Length} bytes)");
        }

        // 복호화
        if (Input.GetKeyDown(KeyCode.W))
        {
            string encryptedPath = Path.Combine(Application.persistentDataPath, "encrypted.dat");
            string decryptedPath = Path.Combine(Application.persistentDataPath, "decrypted.txt");

            using (FileStream inputStream = new FileStream(encryptedPath, FileMode.Open))
            using (FileStream outputStream = new FileStream(decryptedPath, FileMode.Create))
            {
                int key = 0xAB;
                int data;

                while ((data = inputStream.ReadByte()) != -1)
                {
                    int decryptedByte = data ^ key;
                    outputStream.WriteByte((byte)decryptedByte);
                }
            }
            FileInfo fileInfo = new FileInfo(decryptedPath);
            Debug.Log($"{decryptedPath} 복호화 완료");

            string decryptedText = File.ReadAllText(decryptedPath);
            Debug.Log($"복호화 결과: {decryptedText}");

            bool isSame = text == decryptedText;
            Debug.Log($"원본과 일치: {isSame}");
        }
    }
}
