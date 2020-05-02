using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlaneInstaller : MonoInstaller, IControllerFactory
{
    [SerializeField]
    private List<Window> _windows;

    public override void InstallBindings()
    {
        Container.BindInstance(_windows);
        Container.Bind<ViewPool>().AsSingle().WithArguments(_windows);
        Container.Bind<InclinedPlanePhysics>().AsSingle();

        BindControllers();
        Container.Bind(typeof(IControllerFactory)).FromInstance(this).AsSingle();

        Container.Bind<PlaneLoader>().AsSingle().NonLazy();
    }

    public void BindControllers()
    {
        Container.Bind<PlaneRetryWindowController>().AsSingle();

        Container.Bind<PlaneController>().AsSingle();
    }

    public IController CreateController(WindowType type)
    {
        switch (type)
        {
           case WindowType.PlaneRetryWindow:
                return Container.Resolve<PlaneRetryWindowController>();

           case WindowType.PlaneMainWindow:
                return Container.Resolve<PlaneController>();

           default:
                return null;
        }
    }

}