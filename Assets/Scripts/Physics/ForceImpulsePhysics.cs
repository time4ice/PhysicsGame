using System;
public class ForceImpulsePhysics:IForceImpulsePhysics
{
    public float GetSpeedDiffByForce(float force, float duration, float mass)
    {
        return (force * duration) / mass;
    }
}
