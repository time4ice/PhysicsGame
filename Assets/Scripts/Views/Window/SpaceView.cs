using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpaceView: WindowView
{
    [SerializeField]
    private Image _background;

    [SerializeField]
    private Image _surface;

    [SerializeField]
    private RotationSliderView _angleSlider;

    [SerializeField]
    private RocketView _rocket;

    [SerializeField]
    private SliderView _forceSlider;

    [SerializeField]
    private DestinationView _destination;

    [SerializeField]
    private TMP_Text _planetName;

    [SerializeField]
    private TMP_Text _g;

    [SerializeField]
    private string _gFormat;

    [SerializeField]
    private Button _flyButton;

    [SerializeField]
    private TMP_Text _influnceDuration;

    [SerializeField]
    private string _influnceDurationFormat;

    [SerializeField]
    private TMP_Text _mass;

    [SerializeField]
    private string _massFormat;



    public Action<int, int> onFlightStart;

    private void Start()
    {
        _flyButton.onClick.AddListener(() => ReturnValues());
    }

    private void ReturnValues()
    {
        onFlightStart.Invoke(_angleSlider.GetValue(), _forceSlider.GetValue());
    }

    public void Initialize(SpaceInfo spaceInfo, SpaceshipInfo spaceship, PlanetInfo planet, int forceDuration)
    {
        _rocket.Initialize(spaceship);

        _forceSlider.Initialize(spaceInfo.minForce, spaceInfo.maxForce);

        _angleSlider.Initialize(spaceInfo.minAngle, spaceInfo.maxAngle);

        _angleSlider.AddObjectToRotate(_rocket.gameObject);

        _background.sprite = planet.sky.sprite;

        _surface.sprite = planet.surface.sprite;

        _planetName.text = planet.planetName;

        _g.text = string.Format(_gFormat, planet.g);

        _mass.text = string.Format(_massFormat, spaceship.mass);

        _influnceDuration.text = string.Format(_influnceDurationFormat, forceDuration);

    }

    public void SetRocketPosition(Vector3 indent, float angle)
    {
        _rocket.SetPosition(indent, angle);
    }

    public void SetDistance(float distance, float indent)
    {
        _destination.Initialize(_rocket.gameObject.transform.localPosition, distance, indent);
    }

    public void StartMovementAnimation()
    {
        _rocket.StartMovementAnimation();
    }




}