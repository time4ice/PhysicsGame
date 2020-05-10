
using System.Linq;
using UnityEngine;

public class ScalesHandler:IScalesHandler
{
    private ScaleInfo _scale;

     public ScalesHandler()
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
