using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanePrefab:MonoBehaviour
{
    [SerializeField]
    private RectTransform _movingObject;

    [SerializeField]
    private RectTransform _plane;

    [SerializeField]
    private Image _planeMaterial;


    public void Initialize(float length, Sprite material)
    {
        _plane.offsetMax = new Vector2(length, _plane.offsetMax.y);
        _planeMaterial.sprite = material;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            var indent = new Vector3(Time.deltaTime * 20, 0);
            _movingObject.transform.localPosition = - indent;
        }


    }

    public void SetPosition(Vector3 indent)
    {
        _movingObject.anchoredPosition =  - indent;
       
    }

}
