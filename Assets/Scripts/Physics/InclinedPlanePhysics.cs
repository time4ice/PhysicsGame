using System;
using UnityEngine;

public class InclinedPlanePhysics
{
   public float GetDistance(float a, float t)
    {
        return a * t * t * 0.5f;
    }

    public float GetTime(float s, float a)
    {
        return (float)Math.Sqrt((2 * s) / a);
    }

    public float GetAcceleration(float g, float angle, float mu, float m)
    {
        float forces = g * (float)(Math.Sin(angle * Mathf.Deg2Rad) + mu * Math.Cos(angle * Mathf.Deg2Rad));
        return forces;
    }

    public float GetSpeed(float a, float t, float v0)
    {
        return v0 + a * t;
    }
}
