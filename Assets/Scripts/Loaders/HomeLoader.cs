using System;
public class HomeLoader
{
    public HomeLoader(ViewPool _viewPool)
    {
        _viewPool.Get(WindowType.HomeWindow);
    }
}
