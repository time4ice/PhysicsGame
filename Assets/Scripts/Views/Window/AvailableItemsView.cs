using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableItemsView : WindowView
{
    [SerializeField]
    private Transform _grid;

    [SerializeField]
    private ScrollRect _scroll;

    [SerializeField]
    private Button _closeButton;

    public  Action onClose;


    private void Start()
    {
        _closeButton.onClick.AddListener(() => onClose?.Invoke());
    }

    private void OnEnable()
    {
        _scroll.normalizedPosition = new Vector2(0, 0);
    }

    public void SetItems(List<AvailableItem> items)
    {
        foreach(var item in items)
        {
            item.transform.SetParent(_grid);
        }

        _scroll.normalizedPosition = new Vector2(0, 0);
    }
}
