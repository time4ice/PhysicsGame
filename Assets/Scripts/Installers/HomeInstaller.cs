using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HomeInstaller : MonoInstaller<HomeInstaller>, IControllerFactory
{
    [SerializeField]
    private List<Window> _windows;

    public override void InstallBindings()
    {
        Container.BindInstance(_windows);
        Container.Bind<IViewPool>().To<ViewPool>().AsSingle().WithArguments(_windows);
       
        BindControllers();
        Container.Bind(typeof(IControllerFactory)).FromInstance(this).AsSingle();

        Container.Bind<HomeLoader>().AsSingle().NonLazy();
        
    }

    public void BindControllers()
    {
        Container.Bind(typeof(HomeController)).To<HomeController>().AsSingle();

        Container.Bind(typeof(ProfileController)).To<ProfileController>().AsSingle();

        Container.Bind(typeof(AvailableRocketsController)).To<AvailableRocketsController > ().AsSingle();

        Container.Bind(typeof(AvailablePlanetsController)).To<AvailablePlanetsController>().AsSingle();

        Container.Bind(typeof(AvailablePlanesController)).To<AvailablePlanesController>().AsSingle();

    }

    public  IController CreateController(WindowType type)
    {
        switch (type)
        {
            case WindowType.HomeWindow:
                return Container.Resolve<HomeController>();
               
            case WindowType.ProfileWindow:
                return Container.Resolve<ProfileController>();
              
            case WindowType.RocketsWindow:
                return Container.Resolve<AvailableRocketsController>();
               
            case WindowType.PlanetsWindow:
                return Container.Resolve<AvailablePlanetsController>();
              
            case WindowType.MaterialsWindow:
                return Container.Resolve<AvailablePlanesController>();
               
            default:
                return null;
        }
    }

}



