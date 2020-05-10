using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController:IController, IDisposable
{
    private HomeView _view;

    private IViewPool _windowPool;

    public HomeController(IViewPool windowPool)
    {
        _windowPool = windowPool;

        _view = (HomeView)_windowPool.GetView(WindowType.HomeWindow);

        _view.onSceneOpen += OpenScene;
        _view.onWindowOpen += OpenWindow;
    }

    private void OpenWindow(WindowType type)
    {
        IController controller = _windowPool.Get(type);
        controller.Open();
    }

    private void OpenScene(SceneType type)
    {
        SceneLoader.LoadScene(type);
    }

    public void Open(Dictionary<string, object> parameters = null)
    {
       
    }

    public void Dispose()
    {
        _view.onSceneOpen -= OpenScene;

        _view.onWindowOpen -= OpenWindow;
    }
}
