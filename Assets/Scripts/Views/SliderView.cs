using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderView : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private TMP_Text _minText;

    [SerializeField]
    private TMP_Text _maxText;

    [SerializeField]
    private TMP_Text _currentText;

    private int _min;

    private int _max;

    protected int current;

    public void Initialize(int min, int max)
    {
        _min = min;
        _minText.text = _min.ToString();

        _max = max;
        _maxText.text = _max.ToString();

        _slider.onValueChanged.AddListener((value) => { ChangeCurrentValue(value); });

        _slider.value = 0.5f;
    }

    public int GetValue()
    {
        return current;
    }

    protected virtual void ChangeCurrentValue(float sliderValue)
    {
        current = _min + (int)((_max - _min) * sliderValue);
        _currentText.text = current.ToString();
    }
}
