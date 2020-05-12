using System;
public class HomeLoader
{
    public HomeLoader(IViewPool _viewPool)
    {
        _viewPool.GetController(WindowType.HomeWindow);
    }
}
