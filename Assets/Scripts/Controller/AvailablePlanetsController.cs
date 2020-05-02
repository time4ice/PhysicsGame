using System;
using System.Collections.Generic;
using UnityEngine;

public class AvailablePlanetsController : IController
{
    private AvailableItemsView _view;

    private AvailableItem _prefab;

    private ViewPool _windowPool;

    private ProgressHandler _progressHandler;

    private SpaceDataHolder _spaceDataHolder;

    private GameDataHolder _gameDataHolder;

    private List<AvailableItem> _items = new List<AvailableItem>();

    public AvailablePlanetsController(PrefabsHolder prefabsHoder, ViewPool windowPool, ProgressHandler progressHandler, SpaceDataHolder spaceDataHolder, GameDataHolder gameDataHolder)
    {
        _windowPool = windowPool;

        _view = _view = (AvailableItemsView) _windowPool.GetView(WindowType.PlanetsWindow);

        _view.onClose += Close;

        _progressHandler = progressHandler;

        _spaceDataHolder = spaceDataHolder;

        _gameDataHolder = gameDataHolder;

        _prefab = prefabsHoder.GetPrefab<AvailableItem>();

        InstantiateItems();

        _view.SetItems(_items);
    }

    private void InstantiateItems()
    {
        foreach (var planet in _spaceDataHolder.GetPlanets())
        {
            AvailableItem newItem = GameObject.Instantiate(_prefab);

            string info = "Name: " + planet.planetName;

            newItem.SetProperties(planet.icon.sprite, planet.wins, info, _gameDataHolder.GetText(TextType.LockedItemInfo));

            _items.Add(newItem);

        }
    }

    public void Open(Dictionary<string, object> parameters = null)
    {
        _view = _view = (AvailableItemsView)_windowPool.GetView(WindowType.PlanetsWindow);

        int wins = _progressHandler.progress.plane.wins;

        var materials = _spaceDataHolder.GetPlanets();

        for (int i = 0; i < materials.Count; i++)
        {
            bool isOpened = materials[i].wins <= wins;
            _items[i].ChangeOpened(isOpened);
        }
    }

    public void Close()
    {
        _windowPool.Push(WindowType.PlanetsWindow);
    }
}
