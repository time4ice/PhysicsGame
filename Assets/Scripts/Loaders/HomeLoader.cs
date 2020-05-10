using System;
public class HomeLoader
{
    public HomeLoader(IViewPool _viewPool)
    {
        _viewPool.Get(WindowType.HomeWindow);
    }
}
