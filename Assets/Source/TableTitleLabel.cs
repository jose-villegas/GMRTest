using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TableTitleLabel : TableDataTriggerBase
{
    private TextMeshProUGUI _label;

    void Awake()
    {
        // load component
        _label = GetComponent<TextMeshProUGUI>();
    }

    protected override void LoaderOnOnTableLoadFailure()
    {
        _label.text = "Failed to load file content!";
        _label.fontStyle = FontStyles.Normal;
    }

    protected override void OnTableDataChanged(Table table)
    {
        _label.text = table.Title;
        _label.fontStyle = FontStyles.Bold;
    }
}