using System;
using UnityEngine;

public interface IThrownBodyPhysics
{
    Vector3 GetLocationByTime(float speed, float angle, float g, float time);

    float GetRotationByTime(float speed, float angle, float g, float time);

    float GetFlightLength(float speed, float angle, float g);
    
}
