using System;
public interface IViewPool
{
    IController GetController(WindowType type);

    WindowView GetView(WindowType type);

    void Push(WindowType type);
}
