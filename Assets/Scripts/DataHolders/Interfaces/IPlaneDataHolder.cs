using System;
using System.Collections.Generic;

public interface IPlaneDataHolder
{
    PlaneMaterial GetRandomMaterial(int wins);

    PlaneMaterial GetMaterial(string name);

    List<PlaneMaterial> GetMaterials();

    PlaneInfo GetPlaneInfo();
   
}
