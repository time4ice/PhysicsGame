using System;
using TMPro;
using UnityEngine;

public class DestinationView:MonoBehaviour
{
    [SerializeField]
    private RectTransform _arrow;

    [SerializeField]
    private TMP_Text _distanceText;

    [SerializeField]
    private string _distanceTextFormat;

  public void Initialize(Vector3 startPosition, float distance, float indent)
    {
        _distanceText.text = string.Format(_distanceTextFormat, distance*15);

        _arrow.offsetMax=new Vector2 (distance, _arrow.offsetMax.y);
    }
}
