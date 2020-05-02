using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Space/SpaceInfo")]
public class SpaceInfo:ScriptableObject
{
    [Header("Force value limits")]

    [SerializeField]
    private int _minForce;

    public int minForce { get { return _minForce; } }

    [SerializeField]
    private int _maxForce;

    public int maxForce { get { return _maxForce; } }

    [Header("Force duration limits")]

    [SerializeField]
    private int _minTimeForce;

    public int minTimeForce { get { return _minTimeForce; } }

    [SerializeField]
    private int _maxTimeForce;

    public int maxTimeForce { get { return _maxTimeForce; } }

    [Header("Angle limits")]

    [SerializeField]
    private int _minAngle=0;

    public int minAngle { get { return _minAngle; } }

    [SerializeField]
    private int _maxAngle=90;

    public int maxAngle { get { return _maxAngle; } }

    [Header("Touchdown error")]

    [SerializeField]
    private Vector2 _touchdownErrorLimits = new Vector2(10, 100);

    public Vector2 touchdownErrorLimits { get { return _touchdownErrorLimits; } }
}
