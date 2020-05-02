
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController: IController
{
    private SpaceView _view;

    private SpaceInfo _spaceInfo;

    private SpaceshipInfo _ship;

    private PlanetInfo _planet;

    private ViewPool _windowPool;

    private int _forceInfluenceDuration;

    private AsyncProcessor _asyncProcessor;

    private ThrownBodyPhysics _basePhysics;

    private ForceImpulsePhysics _forcePhysics;

    private ProgressHandler _progressHandler;

    private SpaceDataHolder _spaceDataHolder;

    private float _distance;

    private float _time=0;

    public SpaceController(AsyncProcessor asyncProcessor, ViewPool windowPool, ProgressHandler progressHandler, SpaceDataHolder spaceDataHolder, ForceImpulsePhysics forceImpulsePhysics, ThrownBodyPhysics thrownBodyPhysics)
    {
        _windowPool = windowPool;
        _asyncProcessor = asyncProcessor;
        _progressHandler = progressHandler;
        _spaceDataHolder = spaceDataHolder;

        _view = (SpaceView)_windowPool.GetView(WindowType.SpaceMainWindow);

        _basePhysics = thrownBodyPhysics;
        _forcePhysics = forceImpulsePhysics;

        _spaceInfo = _spaceDataHolder.GetSpaceInfo();

        RandomizeValues();

        _view.onFlightStart += ImitateFlight;

        CountDestination();
    }

    private void ImitateFlight(int angle, int force)
    {
        float speed = _forcePhysics.GetSpeedDiffByForce(force, _forceInfluenceDuration, _ship.mass);
        _view.StartMovementAnimation();
        _asyncProcessor.StartCoroutine(FlyCoroutine(angle, speed));
    }

    private IEnumerator FlyCoroutine(int angle, float speed)
    {
        Vector3 indent;
        float distance = _basePhysics.GetFlightLength(speed, angle, _planet.g);
        do
        {
            _time += Time.deltaTime * 10;

            indent = _basePhysics.GetLocationByTime(speed, angle, _planet.g, _time);

            float rotation = _basePhysics.GetRotationByTime(speed, angle, _planet.g, _time);

            _view.SetRocketPosition(indent/15, rotation);

            yield return null;

        } while (indent.x< distance);

        bool isWin = CheckDistanceIndent(distance);
        _progressHandler.AddSpacePoints(isWin ? 1 : -1);
        OpenRetryWindow(isWin);
    }

    private void OpenRetryWindow(bool isWinner)
    {
        IController retryController = _windowPool.Get(WindowType.SpaceRetryWindow);

        Dictionary<string, object> parameters = new Dictionary<string, object>();

        parameters.Add("GameResult", isWinner);

        retryController.Open(parameters);
    }

    private bool CheckDistanceIndent(float currentDistance)
    {
        return currentDistance >= _distance - _spaceInfo.touchdownErrorLimits.x &&
            currentDistance <= _distance + _spaceInfo.touchdownErrorLimits.y;
    }

    private void RandomizeValues()
    {
        _ship = _spaceDataHolder.GetRandomSpaceship(_progressHandler.progress.space.wins);
        _planet = _spaceDataHolder.GetRandomPlanet(_progressHandler.progress.space.wins);
        _forceInfluenceDuration = UnityEngine.Random.Range(_spaceInfo.minTimeForce, _spaceInfo.maxTimeForce);
        _view.Initialize(_spaceInfo, _ship, _planet, _forceInfluenceDuration);
    }

    private void CountDestination()
    {
        float force = UnityEngine.Random.Range(_spaceInfo.minForce, _spaceInfo.maxForce + 1);
        float angle = UnityEngine.Random.Range(_spaceInfo.minAngle, _spaceInfo.maxAngle + 1);

        float speed = _forcePhysics.GetSpeedDiffByForce(force, _forceInfluenceDuration, _ship.mass);
         _distance = _basePhysics.GetFlightLength(speed, angle, _planet.g);
       // _distance = _basePhysics.GetFlightLength(200, 60, _planet.g);

        _view.SetDistance(_distance/15, 1);
    }

    public void Open(Dictionary<string, object> parameters = null)
    {
       
    }
}
