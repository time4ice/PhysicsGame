using System;
public class SpaceLoader
{
    public SpaceLoader(IViewPool _viewPool)
    {
        _viewPool.GetController(WindowType.SpaceMainWindow);
    }
}
