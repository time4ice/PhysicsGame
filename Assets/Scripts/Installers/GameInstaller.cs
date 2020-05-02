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
        Container.Bind<PrefabsHolder>().AsSingle();
        Container.Bind<LocalDataController>().AsSingle();
        Container.Bind<GameDataHolder>().AsSingle();
        Container.Bind<PlaneDataHolder>().AsSingle();
        Container.Bind<SpaceDataHolder>().AsSingle();

    }

}
