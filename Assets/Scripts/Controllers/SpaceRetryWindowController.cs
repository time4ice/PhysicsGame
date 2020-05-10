using System;
using System.Collections.Generic;

public class SpaceRetryWindowController : IController, IDisposable
{
    private RetryWindow _view;

    private IViewPool _windowPool;
    private IGameDataHolder _gameDataHolder;

    public SpaceRetryWindowController(IViewPool windowPool, IGameDataHolder gameDataHolder)
    {
        _windowPool = windowPool;
        _gameDataHolder = gameDataHolder;

        _view = (RetryWindow) _windowPool.GetView(WindowType.SpaceRetryWindow);

        _view.onClose += LoadMainScene;
        _view.onRetry += ReloadScene;
    }

    private void ReloadScene()
    {
        _windowPool.Push(WindowType.SpaceRetryWindow);
        SceneLoader.LoadScene(SceneType.RocketGame);
    }

    private void LoadMainScene()
    {
        SceneLoader.LoadScene(SceneType.HomeScreen);
    }

    public void Open(Dictionary<string, object> parameters)
    {
        bool ifWinner = (bool)parameters["GameResult"];

        TextType textType = ifWinner ? TextType.WinnerSpace : TextType.LooserSpace;

        string text= _gameDataHolder.GetText(textType);

        _view.ShowText(text);

    }

    public void Dispose()
    {
        _view.onClose -= LoadMainScene;
        _view.onRetry -= ReloadScene;
    }
}
