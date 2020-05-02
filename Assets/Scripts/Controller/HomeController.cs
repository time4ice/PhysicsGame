using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController:IController
{
    private HomeView _view;

    private ViewPool _windowPool;

    public HomeController(ViewPool windowPool)
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
}
