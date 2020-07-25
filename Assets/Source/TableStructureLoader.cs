using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class TableStructureLoader : MonoBehaviour
{
    private const string FileName = "JsonChallenge.json";
    private TableStructure _tableStructure;

    private void Awake()
    {
        LoadTable();
    }

    private void LoadTable()
    {
        var path = Application.streamingAssetsPath;
        path = Path.Combine(path, FileName);

        var content = System.IO.File.ReadAllText(path);

        // try to deserialize
        _tableStructure = JsonConvert.DeserializeObject<TableStructure>(content);
    }
}