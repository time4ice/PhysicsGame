using System;
public class SpaceLoader
{
    public SpaceLoader(IViewPool _viewPool)
    {
        _viewPool.Get(WindowType.SpaceMainWindow);
    }
}
