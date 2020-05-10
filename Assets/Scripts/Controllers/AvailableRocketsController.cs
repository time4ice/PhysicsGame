using System;
using System.Collections.Generic;
using UnityEngine;

public class AvailableRocketsController : IController, IDisposable
{
    private AvailableItemsView _view;

    private AvailableItem _prefab;

    private IViewPool _windowPool;

    private ProgressHandler _progressHandler;

    private ISpaceDataHolder _spaceDataHolder;

    private IGameDataHolder _gameDataHolder;

    private List<AvailableItem> _items = new List<AvailableItem>();

    public AvailableRocketsController(IPrefabsHolder prefabsHoder, IViewPool windowPool, ProgressHandler progressHandler, ISpaceDataHolder spaceDataHolder, IGameDataHolder gameDataHolder)
    {
        _windowPool = windowPool;
        _progressHandler = progressHandler;
        _spaceDataHolder = spaceDataHolder;
        _gameDataHolder = gameDataHolder;

        _view = _view = (AvailableItemsView)_windowPool.GetView(WindowType.RocketsWindow);

        _view.onClose += Close;

        _prefab = prefabsHoder.GetPrefab<AvailableItem>();

        InstantiateItems();

        _view.SetItems(_items);
    }

    private void InstantiateItems()
    {
        foreach (var spaceship in _spaceDataHolder.GetSpaceships())
        {
            AvailableItem newItem = GameObject.Instantiate(_prefab);

            string info = "Name: " + spaceship.spaceshipName;

            newItem.SetProperties(spaceship.sprite.sprite, spaceship.wins, info, _gameDataHolder.GetText(TextType.LockedItemInfo));

            _items.Add(newItem);
        }
    }

    public void Open(Dictionary<string, object> parameters = null)
    {
        _view = _view = (AvailableItemsView)_windowPool.GetView(WindowType.RocketsWindow);

        int wins = _progressHandler.progress.plane.wins;

        var materials = _spaceDataHolder.GetSpaceships();

        for (int i = 0; i < materials.Count; i++)
        {
            bool isOpened = materials[i].wins <= wins;
            _items[i].ChangeOpened(isOpened);
        }
    }

    public void Close()
    {
        _windowPool.Push(WindowType.RocketsWindow);
    }

    public void Dispose()
    {
        _view.onClose -= Close;
    }
}
