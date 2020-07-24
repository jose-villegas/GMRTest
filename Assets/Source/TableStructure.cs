using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TableStructure
{
    private string _title;
    private List<string> _headers;
    private List<Dictionary<string, string>> _data;

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public List<string> ColumnHeaders
    {
        get => _headers;
        set => _headers = value;
    }

    public List<Dictionary<string, string>> Data
    {
        get => _data;
        set => _data = value;
    }
}