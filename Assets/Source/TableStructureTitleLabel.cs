using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TableStructureTitleLabel : TableDataTriggerBase
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
    }

    protected override void OnTableDataChanged(TableStructure tableStructure)
    {
        _label.text = tableStructure.Title;
    }
}