using System;
using System.Collections.Generic;

[Serializable]
public class Table
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