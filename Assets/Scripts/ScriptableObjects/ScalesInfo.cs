using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Scales")]
public class ScalesInfo : ScriptableObject
{
    [SerializeField]
    private List<ScaleInfo> _scales;

    public List<ScaleInfo> scales { get { return _scales; } }
}

[Serializable]
public class ScaleInfo
{
    [SerializeField]
    private Vector2 _sizeLimits=new Vector2(0, 1);

    [SerializeField]
    private RocketScale _rocketScale;

    [SerializeField]
    private PlaneScale _planeScale;

    public Vector2 sizeLimits { get { return _sizeLimits; } }

    public RocketScale rocketScale { get { return _rocketScale; } }

    public PlaneScale planeScale { get { return _planeScale; } }

}

[Serializable]
public class RocketScale
{
    [SerializeField]
    private float _heightScale = 15;

    [SerializeField]
    private float _widthScale = 15;

    public float heightScale { get { return _heightScale; } }

    public float widthScale { get { return _widthScale; } }
}

[Serializable]
public class PlaneScale
{
    [SerializeField]
    private float _widthScale = 10;

    public float widthScale { get { return _widthScale; } }
}