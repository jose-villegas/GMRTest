﻿using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class TableDataLoader : MonoBehaviour
{
    public const string FileName = "JsonChallenge.json";

    private Table _tableData;
    private FileWatcher _watcher;

    public event Action<Table> OnTableDataChanged;
    public event Action OnTableLoadFailure;

    private Table LoadedData
    {
        get => _tableData;
        set
        {
            _tableData = value;

            Dispatcher.RunOnMainThread(() =>
            {
                // notify observers
                OnTableDataChanged?.Invoke(_tableData);
            });
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
            LoadedData = JsonConvert.DeserializeObject<Table>(content);
            Debug.LogWarning("Table data changed, loading new data...");
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