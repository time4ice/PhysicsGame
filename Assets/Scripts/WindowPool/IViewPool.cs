using System;
public interface IViewPool
{
    IController Get(WindowType type);

    WindowView GetView(WindowType type);

    void Push(WindowType type);
}
