using UnityEngine;
using System.IO;
using CsvHelper;
using System.Globalization;


public class CSVTest1 : MonoBehaviour
{
    //public TextAsset textAsset;
    public class CSVData
    {
        public string Id { get; set; }
        public string String { get; set; }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var textAsset = Resources.Load<TextAsset>("DataTables/StringTableKr");
            string csv = textAsset.text;

            using (var reader = new StringReader(csv))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<CSVData>();
                foreach (var record in records)
                {
                    Debug.Log($"{record.Id} : {record.String}");
                }
            }
        }
    }
}