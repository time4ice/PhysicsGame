using System;
public interface IControllerFactory
{
    IController CreateController(WindowType type);
}
