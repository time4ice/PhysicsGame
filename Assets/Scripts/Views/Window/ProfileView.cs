using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileView:WindowView
{
    [SerializeField]
    private ProgressViewData _spaceProgress;

    [SerializeField]
    private ProgressViewData _planeProgress;

    [SerializeField]
    private string _winFormat;

    [SerializeField]
    private string _looseFormat;

    [SerializeField]
    private Button _closeButton;

    public Action onClose;

    private void Start()
    {
        _closeButton.onClick.AddListener(() => onClose?.Invoke());
    }

    public void SetSpaceProgress(int wins, int looses)
    {
        _spaceProgress.wins.text = string.Format(_winFormat, wins);
        _spaceProgress.looses.text = string.Format(_looseFormat, looses);
    }

    public void SetPlaneProgress(int wins, int looses)
    {
        _planeProgress.wins.text = string.Format(_winFormat, wins);
        _planeProgress.looses.text = string.Format(_looseFormat, looses);
    }
}

[Serializable]
public class ProgressViewData
{
    [SerializeField]
    public TMP_Text wins;

    [SerializeField]
    public TMP_Text looses;
}
