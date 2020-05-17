using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RocketView:MonoBehaviour
{

    [SerializeField]
    private Image _image;

    [SerializeField]
    private UIParticleSystem _particleSystem;


    private Vector3 _startPosition;

  
   public void Initialize(SpaceshipInfo spaceship)
    {
        _startPosition = transform.localPosition;

        _image.sprite = spaceship.sprite.sprite;

        SetPosition(Vector3.zero, 45);
    }


    public void SetPosition(Vector3 indent, float angle)
    {
        transform.localPosition = _startPosition+indent;
        transform.eulerAngles = new Vector3(0, 0, angle);

        SetParticleRotation(angle);
    }

    private void SetParticleRotation(float angle)
    {
      float x = Mathf.Cos(angle * Mathf.Deg2Rad);

        float y= Mathf.Sin(angle * Mathf.Deg2Rad);

        _particleSystem.ChangeDirection(new Vector2(-x, -y));
    }

    public void StartMovementAnimation()
    {
        _particleSystem.Play();
    }

    internal void StopMovementAnimation()
    {
        _particleSystem.Stop();
    }
}
