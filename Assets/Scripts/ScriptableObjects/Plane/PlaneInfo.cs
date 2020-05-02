using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Plane/PlaneInfo")]
public class PlaneInfo : ScriptableObject
{ 
    [SerializeField]
    private float _g;

    public float g { get { return _g; } }

    [Header("Plane length value limits")]

    [SerializeField]
    private float _minLength;

    public float minLength { get { return _minLength; } }

    [SerializeField]
    private int _maxLength;

    public int maxLength { get { return _maxLength; } }

    [Header("Item mass limits")]

    [SerializeField]
    private int _minMass;

    public int minMass { get { return _minMass; } }

    [SerializeField]
    private int _maxMass;

    public int maxMass { get { return _maxMass; } }

    [Header("Angle limits")]

    [SerializeField]
    private int _minAngle = 0;

    public int minAngle { get { return _minAngle; } }

    [SerializeField]
    private int _maxAngle = 90;

    public int maxAngle { get { return _maxAngle; } }

    [Header("Final speed error")]

    [SerializeField]
    private Vector2 _finalSpeedLimits = new Vector2(10, 100);

    public Vector2 finalSpeedLimits { get { return _finalSpeedLimits; } }
}
