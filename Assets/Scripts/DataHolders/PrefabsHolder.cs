using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabsHolder:IPrefabsHolder
{
    private PrefabsInfo _prefabs;

    public PrefabsHolder()
    {
        LoadAssets();
    }

    public T GetPrefab<T>() where T:BasePrefab
    {
        var items = _prefabs.prefabs.OfType<T>().ToList();
        var item = (T)items[0];
         return item;
    }


    public void LoadAssets()
    {
        _prefabs = (PrefabsInfo)Resources.Load("Prefabs", typeof(PrefabsInfo));
    }
}
