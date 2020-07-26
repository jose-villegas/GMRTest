using UnityEngine;

public abstract class TableDataTriggerBase : MonoBehaviour
{
    [SerializeField] private TableStructureLoader _loader;

    private void OnEnable()
    {
        _loader.OnTableDataChanged += OnTableDataChanged;
        _loader.OnTableLoadFailure += LoaderOnOnTableLoadFailure;
    }

    private void OnDisable()
    {
        _loader.OnTableDataChanged -= OnTableDataChanged;
        _loader.OnTableLoadFailure -= LoaderOnOnTableLoadFailure;
    }

    protected abstract void LoaderOnOnTableLoadFailure();
    protected abstract void OnTableDataChanged(TableStructure tableStructure);
}