using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutGroup))]
public class TableColumnHeadersDisplay : TableDataTriggerBase
{
    private List<TextMeshProUGUI> _columnLabels = new List<TextMeshProUGUI>();

    public List<TextMeshProUGUI> ColumnLabels => _columnLabels;

    protected override void LoaderOnOnTableLoadFailure()
    {
        if (_columnLabels != null && _columnLabels.Count > 0)
        {
            _columnLabels.ForEach(x => x.text = string.Empty);
        }
    }

    protected override void OnTableDataChanged(Table table)
    {
        // check column headers size
        if (table.ColumnHeaders == null)
        {
            Debug.LogWarning("No columns in the table data");
            return;
        }

        var columnsCount = table.ColumnHeaders.Count;

        // match number of child labels with the number of columns
        if (_columnLabels.Count != columnsCount)
        {
            var difference = _columnLabels.Count - columnsCount;

            // we have more labels than needed
            if (difference > 0)
            {
                var toDestroy = _columnLabels.GetRange(_columnLabels.Count - difference - 1, difference);

                toDestroy.ForEach(x => Destroy(x.gameObject));
                _columnLabels.RemoveRange(_columnLabels.Count - difference - 1, difference);
            }
            // we need more labels
            else
            {
                for (int i = 0; i < Math.Abs(difference); i++)
                {
                    var go = new GameObject();
                    go.transform.SetParent(transform);

                    // create text label
                    var label = go.AddComponent<TextMeshProUGUI>();
                    

                    _columnLabels.Add(label);
                }
            }
        }

        SetColumnValues(table);
    }

    protected  virtual void SetColumnValues(Table table)
    {
        // set column header values
        for (int i = 0; i < table.ColumnHeaders.Count && i < _columnLabels.Count; i++)
        {
            _columnLabels[i].text = table.ColumnHeaders[i];
            _columnLabels[i].fontStyle = FontStyles.Bold;
        }
    }
}