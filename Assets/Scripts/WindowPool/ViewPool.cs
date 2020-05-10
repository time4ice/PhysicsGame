using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewPool:IViewPool
{
    private List<Window> _windowPrefabs;

    private Dictionary<WindowType, WindowView> _viewPool= new Dictionary<WindowType, WindowView>();

    private IControllerFactory _controllerFactory;

    public ViewPool(IControllerFactory controllerFactory, List<Window> windowPrefabs)
    {
        _windowPrefabs = windowPrefabs;
       _controllerFactory = controllerFactory;
    }

    public IController Get(WindowType type)
    {
        return _controllerFactory.CreateController(type);
    }

    public WindowView GetView(WindowType type)
    {
        if (!_viewPool.ContainsKey(type))
        {
            var prefab = _windowPrefabs.FirstOrDefault(w => w.type == type).prefab;
            _viewPool.Add(type, GameObject.Instantiate(prefab));
            _viewPool[type].gameObject.SetActive(false);
        }
        _viewPool[type].gameObject.SetActive(true);
        return _viewPool[type];
    }

    public void Push(WindowType type)
    {
        _viewPool[type].gameObject.SetActive(false);
    }
}

[Serializable]
public class Window
{
    [SerializeField]
    public WindowType _type;

    [SerializeField]
    public WindowView _prefab;

    public WindowType type { get { return _type; } }

    public WindowView prefab { get { return _prefab; } }
}

public enum WindowType
{
    SpaceRetryWindow=0,
    PlaneRetryWindow=1,
    ProfileWindow=2,
    RocketsWindow=3,
    MaterialsWindow=4,
    SpaceMainWindow=5,
    PlaneMainWindow=6,
    HomeWindow=7,
    PlanetsWindow=8
}


