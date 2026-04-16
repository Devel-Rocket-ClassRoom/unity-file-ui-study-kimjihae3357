using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SomeClass
{
    public int prefabIndex;
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;
    public Color color;
}

[System.Serializable]
public class SavaData1
{
    public List<SomeClass> objects = new List<SomeClass>();
}

public class JsonTest2 : MonoBehaviour
{
    public string fileName = "test.json";
    public string FileFullPath => Path.Combine(Application.persistentDataPath, "JsonTest", fileName);

    public JsonSerializerSettings jsonSettings;
    public GameObject[] prefabs;
    public int count = 5;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private Dictionary<GameObject, int> spawnedPrefabIndex = new Dictionary<GameObject, int>(); //씬에 있는 오브젝트

    public void Awake()
    {

        jsonSettings = new JsonSerializerSettings();
        jsonSettings.Formatting = Formatting.Indented;
        jsonSettings.Converters.Add(new Vector3Converter());
        jsonSettings.Converters.Add(new QuaternionConverter());
        jsonSettings.Converters.Add(new ColorConverter());

    }
    public void Save()
    {
        string folderPath = Path.GetDirectoryName(FileFullPath);
        Directory.CreateDirectory(folderPath);

        SavaData1 SavaData1 = new SavaData1();

        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            SomeClass data = new SomeClass();
            GameObject obj = spawnedObjects[i];

            data.prefabIndex = spawnedPrefabIndex[obj];
            data.pos = obj.transform.position;
            data.rot = obj.transform.rotation;
            data.scale = obj.transform.localScale;
            data.color = obj.GetComponent<Renderer>().material.color;
            SavaData1.objects.Add(data);

        }
        var json = JsonConvert.SerializeObject(SavaData1, jsonSettings);
        File.WriteAllText(FileFullPath, json);
        Debug.Log("세이브 완료");
    }

    public void Load()
    {
        string json = File.ReadAllText(FileFullPath);
        SavaData1 SavaData1 = JsonConvert.DeserializeObject<SavaData1>(json, jsonSettings);

        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
        spawnedObjects.Clear();
        spawnedPrefabIndex.Clear();

        for (int i = 0; i < SavaData1.objects.Count; i++)
        {
            SomeClass data = SavaData1.objects[i];
            GameObject obj = Instantiate(prefabs[data.prefabIndex], data.pos, data.rot);
            obj.transform.localScale = data.scale;
            obj.GetComponent<Renderer>().material.color = data.color;

            spawnedObjects.Add(obj);
            spawnedPrefabIndex[obj] = data.prefabIndex;
        }
        Debug.Log("로드 완료");
    }

    public void Create()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnpos = new Vector3(
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f),
                0f
            );

            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject obj = Instantiate(prefabs[randomIndex], spawnpos, Quaternion.identity);
            spawnedObjects.Add(obj);
            spawnedPrefabIndex[obj] = randomIndex;
        }
    }

    public void Clear()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
            Destroy(spawnedObjects[i]);
        spawnedObjects.Clear();
        spawnedPrefabIndex.Clear();

        Debug.Log("전체 삭제");
    }

}
