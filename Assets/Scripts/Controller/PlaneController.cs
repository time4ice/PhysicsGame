using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController: IController
{
    private PlaneView _view;

    private PlaneMaterial _material;

    private ViewPool _windowPool;

    private float _planeLength;

    private AsyncProcessor _asyncProcessor;

    private InclinedPlanePhysics _basePhysics;

    private ProgressHandler _progressHandler;

    private PlaneDataHolder _planeDataHolder;

    private PlaneInfo _planeInfo;

    private float _speed;

    private float _time = 0;

    public PlaneController(AsyncProcessor asyncProcessor, ViewPool windowPool, ProgressHandler progressHandler, PlaneDataHolder planeDataHolder, InclinedPlanePhysics physics)
    {
        _windowPool = windowPool;
        _asyncProcessor = asyncProcessor;
        _progressHandler = progressHandler;
        _planeDataHolder = planeDataHolder;

        _view = _view = (PlaneView)_windowPool.GetView(WindowType.PlaneMainWindow);

        _basePhysics = physics;
        _planeInfo = _planeDataHolder.GetPlaneInfo();

        RandomizeValues();

        _view.onMoveStart += ImitateMove;

        CountSpeed();
    }

    private void ImitateMove(float angle, float mass)
    {
        _asyncProcessor.StartCoroutine(MoveCoroutine(angle, mass));
    }

    private IEnumerator MoveCoroutine(float angle, float mass)
    {
        float distance;
        float a = _basePhysics.GetAcceleration(_planeInfo.g, angle, _material.mu, mass);
        float finalSpeed = _basePhysics.GetSpeed(a, _basePhysics.GetTime(_planeLength, a), 0);
        do
        {
            _time += Time.deltaTime * 10;

            distance = _basePhysics.GetDistance(a, _time);

            Vector3 indent = new Vector3(distance, 0);

            float speed = _basePhysics.GetSpeed(a, _time, 0);

            _view.SetObjectPosition(indent);

            _view.SetCurrentSpeed(speed);

            yield return null;

        } while (distance < _planeLength);

        bool isWin = CheckSpeedIndent(finalSpeed);
        _progressHandler.AddPlanePoints(isWin ? 1 : -1);
        OpenRetryWindow(isWin);
    }

    private void OpenRetryWindow(bool isWinner)
    {
        IController retryController = _windowPool.Get(WindowType.PlaneRetryWindow);

        Dictionary<string, object> parameters = new Dictionary<string, object>();

        parameters.Add("GameResult", isWinner);

        retryController.Open(parameters);
    }

    private bool CheckSpeedIndent(float currentFinalSpeed)
    {
        return currentFinalSpeed >= _speed - _planeInfo.finalSpeedLimits.x &&
            currentFinalSpeed <= _speed + _planeInfo.finalSpeedLimits.y;
    }

    private void RandomizeValues()
    {
        _material = _planeDataHolder.GetRandomMaterial(_progressHandler.progress.plane.wins);
        _planeLength = UnityEngine.Random.Range(_planeInfo.minLength, _planeInfo.maxLength+1);
        _view.Initialize(_planeInfo, _material, _planeLength);
    }

    private void CountSpeed()
    {
        float angle = 30;// UnityEngine.Random.Range(_planeInfo.minAngle, _planeInfo.maxAngle + 1);
        float mass = 120;// UnityEngine.Random.Range(_planeInfo.minMass, _planeInfo.maxMass + 1);

        float a = _basePhysics.GetAcceleration(_planeInfo.g, angle, _material.mu, mass);
        Debug.Log("time: " + _basePhysics.GetTime(20, a));
        _speed = _basePhysics.GetSpeed(a, _basePhysics.GetTime(_planeLength, a), 0);

        _view.SetFinalSpeed(_speed);
    }

    public void Open(Dictionary<string, object> parameters = null)
    {
        
    }
}
