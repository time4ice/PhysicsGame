using System;
public class ForceImpulsePhysics
{
    public float GetSpeedDiffByForce(float force, float duration, float mass)
    {
        return (force * duration) / mass;
    }
}
