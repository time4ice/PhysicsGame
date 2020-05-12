using System;
public class PlaneLoader
{
    public PlaneLoader(IViewPool _viewPool)
    {
        _viewPool.GetController(WindowType.PlaneMainWindow);
    }
   
}
