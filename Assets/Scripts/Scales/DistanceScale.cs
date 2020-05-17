using System;
using UnityEngine;

public class DistanceScale:IDistanceScale
{
    private float _coeff;

    public float coeff => _coeff;

    public DistanceScale(IScalesHolder scalesHolder, ISpaceDataHolder spaceDataHolder, IForceImpulsePhysics forceImpulsePhysics, IThrownBodyPhysics thrownBodyPhysics)
    {
        float scaleFactor = scalesHolder.GetRocketScale().widthScale;

        var spaceInfo = spaceDataHolder.GetSpaceInfo();

        float speed = forceImpulsePhysics.GetSpeedDiffByForce(spaceInfo.maxForce, spaceInfo.maxTimeForce, spaceDataHolder.GetMinSpaceshipMass());

        float maxDistance = thrownBodyPhysics.GetFlightLength(speed, 45, spaceDataHolder.GetMinG());

        _coeff = scaleFactor / maxDistance;

    }
}
