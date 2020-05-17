using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaneView:WindowView
{

    [SerializeField]
    private SliderView _massSlider;

    [SerializeField]
    private RotationSliderView _angleSlider;

    [SerializeField]
    private TMP_Text _materialText;

    [SerializeField]
    private string _materialFormat;

    [SerializeField]
    private TMP_Text _muText;

    [SerializeField]
    private string _muFormat;

    [SerializeField]
    private TMP_Text _lengthText;

    [SerializeField]
    private string _lengthFormat;

    [SerializeField]
    private TMP_Text _neededSpeedText;

    [SerializeField]
    private string _neededSpeedFormat;

    [SerializeField]
    private TMP_Text _currentSpeedText;

    [SerializeField]
    private string _currentSpeedFormat;

    [SerializeField]
    private Button _moveButton;

    [SerializeField]
    private PlanePrefab _plane;

    private bool _isButtonlocked;


    public Action<float, float> onMoveStart;

    private void Start()
    {
        _moveButton.onClick.AddListener(() => ReturnValues());
    }

    public void Initialize(PlaneInfo planeInfo, PlaneMaterial material, float length)
    {
        _plane.Initialize(length, material.view.sprite);
        _massSlider.Initialize(planeInfo.minMass, planeInfo.maxMass);
       
        _angleSlider.AddObjectToRotate(_plane.gameObject);
        _angleSlider.Initialize(planeInfo.minAngle, planeInfo.maxAngle);


        _materialText.text = string.Format(_materialFormat, material.materialName);

        _muText.text = string.Format(_muFormat, material.mu);

        _lengthText.text = string.Format(_lengthFormat, length);

    }

    private void ReturnValues()
    {
        if (!_isButtonlocked)
        {
            _isButtonlocked = true;
            onMoveStart.Invoke(_angleSlider.GetValue(), _massSlider.GetValue());
        }
    }


    public void SetObjectPosition(Vector3 indent)
    {
        _plane.SetPosition(indent);
    }

    public void SetCurrentSpeed(float speed)
    {
        _currentSpeedText.text = string.Format(_currentSpeedFormat, (int) speed);
    }

    public void SetFinalSpeed(float speed)
    {
       _neededSpeedText.text = string.Format(_neededSpeedFormat, speed);
    }

    public void StartMovementAnimation()
    {
        _plane.StartMovementAnimation(_angleSlider.GetValue());
    }

    public void StopMovementAnimation()
    {
        _plane.StopMovementAnimation();
    }

}
