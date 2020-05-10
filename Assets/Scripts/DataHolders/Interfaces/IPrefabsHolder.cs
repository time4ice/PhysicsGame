using System;
public interface IPrefabsHolder
{
    T GetPrefab<T>() where T : BasePrefab;
}
