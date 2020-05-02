using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Plane/PlaneMaterial")]
public class PlaneMaterial:ScriptableObject
{
    [SerializeField]
    private int _wins;

    [SerializeField]
    private string _materialName;

    [SerializeField]
    private SpriteView _view;

    [SerializeField]
    private SpriteView _icon;

    [SerializeField]
    private float _mu;

    public string materialName { get { return _materialName; } }

    public SpriteView view { get { return _view; } }

    public SpriteView icon { get { return _icon; } }

    public float mu { get { return _mu; } }

    public int wins { get { return _wins; } }
}
