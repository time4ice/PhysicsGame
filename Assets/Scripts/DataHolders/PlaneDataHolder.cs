using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneDataHolder:IPlaneDataHolder
{
    private List<PlaneMaterial> _materials = new List<PlaneMaterial>();

    private PlaneInfo _planeInfo;

    public PlaneDataHolder()
    {
        LoadAssets();
    }

    public PlaneMaterial GetRandomMaterial(int wins)
    {
        return _materials.Where(s => s.wins <= wins).ToList().GetRandom();
    }

    public PlaneMaterial GetMaterial(string name)
    {
        return _materials.FirstOrDefault(s => s.name == name);
    }

    public List<PlaneMaterial> GetMaterials()
    {
        return _materials.OrderBy(s=>s.wins).ToList();
    }

    public PlaneInfo GetPlaneInfo()
    {
        return _planeInfo;
    }

    private void LoadAssets()
    {
        foreach (PlaneMaterial conf in Resources.LoadAll("Materials", typeof(PlaneMaterial)))
        {
            _materials.Add(conf);
        }

        _planeInfo = (PlaneInfo)Resources.Load("PlaneInfo", typeof(PlaneInfo));
    }
}
