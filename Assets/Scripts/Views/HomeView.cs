using System;
using UnityEngine;
using UnityEngine.UI;

public class HomeView: WindowView
{
    [SerializeField]
    private Button _rocketsButton;

    [SerializeField]
    private Button _materialsButton;

    [SerializeField]
    private Button _profileButton;

    [SerializeField]
    private Button _rocketGameButton;

    [SerializeField]
    private Button _planetsGameButton;

    [SerializeField]
    private Button _planeGameButton;

    public Action<SceneType> onSceneOpen;

    public Action<WindowType> onWindowOpen;

    private void Start()
    {
        _rocketsButton.onClick.AddListener(() => onWindowOpen?.Invoke(WindowType.RocketsWindow));

        _planetsGameButton.onClick.AddListener(() => onWindowOpen?.Invoke(WindowType.PlanetsWindow));

        _materialsButton.onClick.AddListener(() => onWindowOpen?.Invoke(WindowType.MaterialsWindow));

        _profileButton.onClick.AddListener(() => onWindowOpen?.Invoke(WindowType.ProfileWindow));

        _rocketGameButton.onClick.AddListener(() => onSceneOpen?.Invoke(SceneType.RocketGame));

        _planeGameButton.onClick.AddListener(() => onSceneOpen?.Invoke(SceneType.PlaneGame));
    }
}
