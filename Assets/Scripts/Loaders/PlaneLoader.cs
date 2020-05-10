using System;
public class PlaneLoader
{
    public PlaneLoader(IViewPool _viewPool)
    {
        _viewPool.Get(WindowType.PlaneMainWindow);
    }
   
}
