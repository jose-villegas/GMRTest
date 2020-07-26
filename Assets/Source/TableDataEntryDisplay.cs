public class TableDataEntryDisplay : TableColumnHeadersDisplay
{
    private int _dataEntryIndex = 0;

    protected override void SetColumnValues(Table table)
    {
        // set column header values
        for (int i = 0; i < table.ColumnHeaders.Count && i < ColumnLabels.Count; i++)
        {
            ColumnLabels[i].text = table.ColumnHeaders[i];
        }
    }
}