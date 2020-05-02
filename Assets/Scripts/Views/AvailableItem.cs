using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvailableItem:BasePrefab
{
    [SerializeField]
    private Image _icon;

    [SerializeField]
    private GameObject _lockMask;

    [SerializeField]
    private TMP_Text _info;

    [SerializeField]
    private TMP_Text _level;

    [SerializeField]
    private string _infoFormat;

    [SerializeField]
    private string _levelFormat;

    private string _infoText;

    private string _lockedInfoText;

    public void SetProperties(Sprite icon, int level, string info, string lockedInfo)
    {
        _icon.sprite = icon;
        _level.text = string.Format(_levelFormat, level);
        _infoText = info;
        _lockedInfoText = lockedInfo;
    }

    public void ChangeOpened(bool isOpened)
    {
        _icon.gameObject.SetActive(isOpened);
        _lockMask.SetActive(!isOpened);
        _info.text = string.Format(_infoFormat, isOpened?_infoText:_lockedInfoText);
    }

}
