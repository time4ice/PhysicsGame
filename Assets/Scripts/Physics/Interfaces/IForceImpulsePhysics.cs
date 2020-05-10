using System;
public interface IForceImpulsePhysics
{
    float GetSpeedDiffByForce(float force, float duration, float mass);
}
