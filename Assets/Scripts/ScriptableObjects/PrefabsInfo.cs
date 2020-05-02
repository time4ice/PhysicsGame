using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Prefabs")]
public class PrefabsInfo : ScriptableObject
{
    [SerializeField]
    private List<BasePrefab> _prefabs;

    public List<BasePrefab> prefabs { get { return _prefabs; } }
}