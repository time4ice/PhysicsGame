using System;
using System.Collections.Generic;

public class PlaneRetryWindowController : IController, IDisposable
{
    private RetryWindow _view;

    private IViewPool _windowPool;

    private IGameDataHolder _gameDtaHolder;

    public PlaneRetryWindowController(IViewPool windowPool, IGameDataHolder gameDtaHolder)
    {
        _windowPool = windowPool;
        _gameDtaHolder = gameDtaHolder;
       
        _view = (RetryWindow) _windowPool.GetView(WindowType.PlaneRetryWindow);

        _view.onClose += LoadMainScene;
        _view.onRetry += ReloadScene;  
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

    public void Dispose()
    {
        _view.onClose -= LoadMainScene;
        _view.onRetry -= ReloadScene;
    }
}
