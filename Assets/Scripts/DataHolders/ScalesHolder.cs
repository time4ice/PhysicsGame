
using System;
using System.Linq;
using UnityEngine;

public class ScalesHolder:IScalesHolder
{
    private ScaleInfo _scale;

     public ScalesHolder()
    {
        LoadAssets();
    }

    
    public PlaneScale GetPlaneScale()
    {
        return _scale.planeScale;
    }

    public RocketScale GetRocketScale()
    {
        return _scale.rocketScale;
    }

    private void LoadAssets()
    {
        ScalesInfo scales = (ScalesInfo)Resources.Load("ScalesInfo", typeof(ScalesInfo));
        float ratio = CountRatio();

        _scale = scales.scales.FirstOrDefault(s => s.sizeLimits.x < ratio && s.sizeLimits.y > ratio);
    }

    private float CountRatio()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;

        return height / width;       
    }
}
