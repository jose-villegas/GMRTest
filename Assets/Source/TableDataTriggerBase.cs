using UnityEngine;

public abstract class TableDataTriggerBase : MonoBehaviour
{
    [SerializeField] private TableDataLoader _loader;

    protected TableDataLoader Loader
    {
        get => _loader;
        set => _loader = value;
    }

    private void OnEnable()
    {
        if (_loader == null)
        {
            Debug.LogWarning("No loader assigned");
            return;
        }

        _loader.OnTableDataChanged += OnTableDataChanged;
        _loader.OnTableLoadFailure += LoaderOnOnTableLoadFailure;
    }

    private void OnDisable()
    {
        if (_loader == null)
        {
            Debug.LogWarning("No loader assigned");
            return;
        }

        _loader.OnTableDataChanged -= OnTableDataChanged;
        _loader.OnTableLoadFailure -= LoaderOnOnTableLoadFailure;
    }

    protected abstract void LoaderOnOnTableLoadFailure();
    protected abstract void OnTableDataChanged(Table table);
}