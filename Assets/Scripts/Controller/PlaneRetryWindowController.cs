using System;
using System.Collections.Generic;

public class PlaneRetryWindowController : IController
{
    private RetryWindow _view;

    private ViewPool _windowPool;

    private GameDataHolder _gameDtaHolder;

    public PlaneRetryWindowController(ViewPool windowPool, GameDataHolder gameDtaHolder)
    {
        _windowPool = windowPool;
        _view = (RetryWindow) _windowPool.GetView(WindowType.PlaneRetryWindow);

        _view.onClose += LoadMainScene;

        _view.onRetry += ReloadScene;
        _gameDtaHolder = gameDtaHolder;
    }

    private void ReloadScene()
    {
        _windowPool.Push(WindowType.PlaneRetryWindow);
        SceneLoader.LoadScene(SceneType.PlaneGame);
    }

    private void LoadMainScene()
    {
        SceneLoader.LoadScene(SceneType.HomeScreen);
    }

    public void Open(Dictionary<string, object> parameters)
    {
        bool ifWinner = (bool)parameters["GameResult"];

        TextType textType = ifWinner ? TextType.WinnerPlane : TextType.LooserPlane;

        string text = _gameDtaHolder.GetText(textType);

        _view.ShowText(text);

    }
}
