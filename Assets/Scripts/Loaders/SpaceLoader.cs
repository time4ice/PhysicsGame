using System;
public class SpaceLoader
{
    public SpaceLoader(ViewPool _viewPool)
    {
        _viewPool.Get(WindowType.SpaceMainWindow);
    }
}
