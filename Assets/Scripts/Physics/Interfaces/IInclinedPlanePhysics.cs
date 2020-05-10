using System;
public interface IInclinedPlanePhysics
{
    float GetDistance(float a, float t);

    float GetTime(float s, float a);

    float GetAcceleration(float g, float angle, float mu, float m);

    float GetSpeed(float a, float t, float v0);
}
