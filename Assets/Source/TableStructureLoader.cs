using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class TableStructureLoader : MonoBehaviour
{
    public const string FileName = "JsonChallenge.json";

    private TableStructure _tableData;
    private FileWatcher _watcher;

    public event Action<TableStructure> OnTableDataChanged;
    public event Action OnTableLoadFailure;

    private TableStructure LoadedData
    {
        get => _tableData;
        set
        {
            _tableData = value;

            // notify observers
            OnTableDataChanged?.Invoke(_tableData);
        }
    }

    private void Awake()
    {
        // start watching the file content changes
        _watcher = new FileWatcher();
        _watcher.Start(Application.streamingAssetsPath, FileName, OnFileContentChanged);
    }

    private void Start()
    {
        // load initial table if existing
        LoadTable();
    }

    /// <summary>
    /// Loads the file containing the table structure
    /// </summary>
    private void LoadTable()
    {
        try
        {
            var path = Application.streamingAssetsPath;
            path = Path.Combine(path, FileName);

            var content = System.IO.File.ReadAllText(path);

            // try to deserialize
            LoadedData = JsonConvert.DeserializeObject<TableStructure>(content);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            OnTableLoadFailure?.Invoke();
        }
    }

    private void OnFileContentChanged(object sender, FileSystemEventArgs e)
    {
        LoadTable();
    }
}