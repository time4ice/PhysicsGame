using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private AsyncProcessor _asyncProcessor;

    public override void InstallBindings()
    {
        Debug.Log("GameInstaller");
        Container.BindInstance(_asyncProcessor);

        Container.Bind(typeof(IDisposable), typeof(ProgressHandler)).To<ProgressHandler>().AsSingle();

        Container.Bind<IPrefabsHolder>().To<PrefabsHolder>().AsSingle();

        Container.Bind<ILocalDataController>().To<LocalDataController>().AsSingle();

        Container.Bind<IGameDataHolder>().To<GameDataHolder>().AsSingle();
        Container.Bind<IScalesHandler>().To<ScalesHandler>().AsSingle();

        Container.Bind<IPlaneDataHolder>().To<PlaneDataHolder>().AsSingle();
        Container.Bind<ISpaceDataHolder>().To<SpaceDataHolder>().AsSingle();
    }

}
