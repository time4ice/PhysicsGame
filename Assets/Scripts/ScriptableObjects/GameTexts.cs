using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameTexts")]
public class GameTexts:ScriptableObject
{
    [SerializeField]
    private List<GameText> _gameTexts;

    public List<GameText> gameTexts { get { return _gameTexts; } }
}

[Serializable]
public class GameText
{
    [SerializeField]
    private TextType _type;

    [SerializeField]
    private string _phrase;

    public TextType type { get { return _type; } }

    public string phrase { get { return _phrase; } }

}

public enum TextType
{
    WinnerSpace,
    LooserSpace,
    WinnerPlane,
    LooserPlane,
    LockedItemInfo
}
