using System;
using UnityEngine;

public class ThrownBodyPhysics
{ 
    public Vector3 GetLocationByTime(float speed, float angle, float g, float time)
    {
        float x = speed * (float)Math.Cos(angle * Mathf.Deg2Rad) * time;
        float y = (speed * (float)Math.Sin(angle * Mathf.Deg2Rad) * time - g * time * time * 0.5f);

        return new Vector3(x, y);
    }

    public float GetRotationByTime(float speed, float angle, float g, float time)
    {
        var vx = speed * (float)Math.Cos(angle * Mathf.Deg2Rad);
        var vy = speed * (float)Math.Sin(angle * Mathf.Deg2Rad) - g * time;

        var tg = vy / vx;
        var rotation = (float)Math.Atan(tg) * Mathf.Rad2Deg;

        return rotation;
    }

    public float GetFlightLength(float speed, float angle, float g)
    {
        return (speed * speed * (float)Math.Sin(2 * angle * Mathf.Deg2Rad)) / g;
    }
}
