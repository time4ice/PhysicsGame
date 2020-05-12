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

    [SerializeField]
    private UIParticleSystem _particleSystem;


    public void Initialize(float length, Sprite material)
    {
        _plane.offsetMax = new Vector2(length, _plane.offsetMax.y);
        _planeMaterial.sprite = material;
    }

    public void SetPosition(Vector3 indent)
    {
        _movingObject.anchoredPosition =  - indent;
       
    }

    private void SetParticleRotation(float angle)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);

        float y = Mathf.Sin(angle * Mathf.Deg2Rad);

        _particleSystem.ChangeDirection(new Vector2(x, y));
    }

    public void StartMovementAnimation(float angle)
    {
        SetParticleRotation(angle);
        _particleSystem.Play();
    }

}
