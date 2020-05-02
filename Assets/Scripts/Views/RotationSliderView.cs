using System;
using System.Collections.Generic;
using UnityEngine;

public class RotationSliderView:SliderView
{
    private List<GameObject> _objectsToRotate=new List<GameObject>();

    public void AddObjectToRotate(GameObject obj)
    {
        _objectsToRotate.Add(obj);
    }

    protected override void ChangeCurrentValue(float sliderValue)
    {
        base.ChangeCurrentValue(sliderValue);

        foreach(var obj in _objectsToRotate)
        {
            obj.transform.eulerAngles = new Vector3(0, 0, current);
        }
    }
}
