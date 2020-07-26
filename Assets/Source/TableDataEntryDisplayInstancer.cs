using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableDataEntryDisplayInstancer : TableDataTriggerBase
{
    [SerializeField] private LayoutGroup _entryLayout;

    private List<TableDataEntryDisplay> _entries = new List<TableDataEntryDisplay>();

    protected override void LoaderOnOnTableLoadFailure()
    {
    }

    protected override void OnTableDataChanged(Table table)
    {
        // check column headers size
        if (table.Data == null)
        {
            Debug.LogWarning("No data entries in the table data");
            return;
        }

        var entriesCount = table.Data.Count;

        _entries.ForEach(x => x.gameObject.SetActive(false));

        if (entriesCount != _entries.Count)
        {
            var difference = _entries.Count - entriesCount;

            // we have more entries than needed
            if (difference > 0)
            {
                var toDestroy = _entries.GetRange(_entries.Count - difference - 1, difference);

                toDestroy.ForEach(x => Destroy(x.gameObject));
                _entries.RemoveRange(_entries.Count - difference - 1, difference);
            }
            // we need more entries
            else
            {
                var startFrom = _entries.Count;
                var endAt = startFrom + Math.Abs(difference);

                for (int i = startFrom; i < endAt; i++)
                {
                    var layout = Instantiate(_entryLayout, transform);
                    _entries.Add(TableDataEntryDisplay.CreateEntry(layout, Loader));
                }
            }
        }

        for (var i = 0; i < _entries.Count; i++)
        {
            _entries[i].gameObject.SetActive(true);
            _entries[i].Refresh(i, table);
        }
    }
}