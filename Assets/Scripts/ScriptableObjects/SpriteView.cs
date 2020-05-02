using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SpriteView")]
public class SpriteView : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite=null;

    public Sprite sprite { get { return _sprite; } }
}
