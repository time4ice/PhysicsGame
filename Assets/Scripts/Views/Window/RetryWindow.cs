using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RetryWindow:WindowView
{
    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Button _retryButton;

    [SerializeField]
    private Button _closeButton;

    public Action onRetry;
    public Action onClose;

    public void Start()
    {
        _retryButton.onClick.AddListener(() => onRetry?.Invoke());
        _closeButton.onClick.AddListener(() => onClose?.Invoke());
    }

    public void ShowText(string text)
    {
       _text.text = text;
    }

}
