using System;
using System.Collections.Generic;

public class ProfileController : IController
{
    private ProgressHandler _progress;

    private ProfileView _view;

    private ViewPool _windowPool;

    public ProfileController(ProgressHandler progress, ViewPool windowPool)
    {
        _windowPool = windowPool;
        _progress = progress;
        _view = (ProfileView)_windowPool.GetView(WindowType.ProfileWindow);
       

        _view.onClose += Close;
    }

    public void Open(Dictionary<string, object> parameters = null)
    {
        _view = (ProfileView)_windowPool.GetView(WindowType.ProfileWindow);

        _view.SetPlaneProgress(_progress.progress.plane.wins, _progress.progress.plane.looses);

        _view.SetSpaceProgress(_progress.progress.space.wins, _progress.progress.space.looses);
    }

    public void Close()
    {
        _windowPool.Push(WindowType.ProfileWindow);
    }
}
