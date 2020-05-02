using System;
using System.Collections.Generic;

public class SpaceRetryWindowController : IController
{
    private RetryWindow _view;

    private ViewPool _windowPool;
    private GameDataHolder _gameDataHolder;

    public SpaceRetryWindowController(ViewPool windowPool, GameDataHolder gameDataHolder)
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
}
