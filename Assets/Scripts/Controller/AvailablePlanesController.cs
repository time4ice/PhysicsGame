using System;
using System.Collections.Generic;
using UnityEngine;

public class AvailablePlanesController : IController
{
    private AvailableItemsView _view;

    private AvailableItem _prefab;

    private ViewPool _windowPool;

    private ProgressHandler _progressHandler;

    private PlaneDataHolder _planeDataHolder;

    private GameDataHolder _gameDataHolder;

    private List<AvailableItem> _items= new List<AvailableItem>();

    public AvailablePlanesController(PrefabsHolder prefabsHoder, ViewPool windowPool, ProgressHandler progressHandler, PlaneDataHolder planeDataHolder, GameDataHolder gameDataHolder)
    {
        _windowPool = windowPool;

        _view = (AvailableItemsView) _windowPool.GetView(WindowType.MaterialsWindow);

        _view.onClose += Close;

        _progressHandler = progressHandler;
        _planeDataHolder = planeDataHolder;
        _gameDataHolder = gameDataHolder;

        _prefab = prefabsHoder.GetPrefab<AvailableItem>();

        InstantiateItems();

        _view.SetItems(_items);
    }

    private void InstantiateItems()
    {
        foreach(var material in _planeDataHolder.GetMaterials())
        {
            AvailableItem newItem = GameObject.Instantiate(_prefab);

            string info = "Name: " + material.materialName;

            newItem.SetProperties(material.icon.sprite, material.wins, info, _gameDataHolder.GetText(TextType.LockedItemInfo));

            _items.Add(newItem);

        }
    }

    public void Open(Dictionary<string, object> parameters = null)
    {
        _view = (AvailableItemsView)_windowPool.GetView(WindowType.MaterialsWindow);

        int wins = _progressHandler.progress.plane.wins;

        var materials = _planeDataHolder.GetMaterials();

        for (int i = 0; i < materials.Count; i++)
        {
            bool isOpened = materials[i].wins <= wins;
            _items[i].ChangeOpened(isOpened);
        }
    }

    public void Close()
    {
        _windowPool.Push(WindowType.MaterialsWindow);
    }
}
