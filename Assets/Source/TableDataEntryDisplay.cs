using UnityEngine;
using UnityEngine.UI;

public class TableDataEntryDisplay : TableColumnHeadersDisplay
{
    private int _dataEntryIndex = 0;

    public void Refresh(int index, Table table)
    {
        _dataEntryIndex = index;
        OnTableDataChanged(table);
    }

    protected override void SetColumnValues(Table table)
    {
        if (table.Data == null)
        {
            Debug.LogWarning("There is no data entries in the table");
            return;
        }

        if (_dataEntryIndex < 0 || _dataEntryIndex >= table.Data.Count)
        {
            Debug.LogWarning("Invalid index for this data entry components");
            return;
        }

        var entry = table.Data[_dataEntryIndex];

        // set column header values
        for (int i = 0; i < table.ColumnHeaders.Count && i < ColumnLabels.Count; i++)
        {
            var key = table.ColumnHeaders[i];

            ColumnLabels[i].text = entry.TryGetValue(key, out var value) ? value : string.Empty;
        }
    }

    /// <summary>
    /// Factory method to create table data entries display components
    /// </summary>
    /// <param name="layout">The base gameObject containing the required
    /// <see cref="UnityEngine.UI.LayoutGroup"/></param>
    /// <param name="index">The data entry index number in <see cref="Table.Data"/></param>
    /// <returns></returns>
    public static TableDataEntryDisplay CreateEntry(LayoutGroup layout, TableDataLoader loader)
    {
        var component = layout.gameObject.AddComponent<TableDataEntryDisplay>();
        component.Loader = loader;
        return component;
    }
}