using System;
public class PlaneLoader
{
    public PlaneLoader(ViewPool _viewPool)
    {
        _viewPool.Get(WindowType.PlaneMainWindow);
    }
   
}
