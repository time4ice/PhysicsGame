using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpaceInstaller : MonoInstaller, IControllerFactory
{
    [SerializeField]
    private List<Window> _windows;

    public override void InstallBindings()
    {
        Container.BindInstance(_windows);
        Container.Bind<IViewPool>().To<ViewPool>().AsSingle().WithArguments(_windows);
        Container.Bind<IThrownBodyPhysics>().To<ThrownBodyPhysics>().AsSingle();
        Container.Bind<IForceImpulsePhysics>().To<ForceImpulsePhysics>().AsSingle();
        Container.Bind<IDistanceScale>().To<DistanceScale>().AsSingle().NonLazy();

        BindControllers();
        Container.Bind(typeof(IControllerFactory)).FromInstance(this).AsSingle();

        Container.Bind<SpaceLoader>().AsSingle().NonLazy();
    }

    public void BindControllers()
    {
        Container.Bind(typeof(SpaceRetryWindowController)).To<SpaceRetryWindowController>().AsSingle();

        Container.Bind(typeof(SpaceController)).To<SpaceController>().AsSingle();
    }

    public IController CreateController(WindowType type)
    {
        switch (type)
        {
            case WindowType.SpaceRetryWindow:
                return Container.Resolve<SpaceRetryWindowController>();

            case WindowType.SpaceMainWindow:
                return Container.Resolve<SpaceController>();

            default:
                return null;
        }
    }

}