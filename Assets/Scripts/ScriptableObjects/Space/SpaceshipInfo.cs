using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Space/Spaceship")]
public class SpaceshipInfo : ScriptableObject
{
    [SerializeField]
    private int _wins;

    [SerializeField]
    private string _spaceshipName;

    [SerializeField]
    private SpriteView _sprite;

    [SerializeField]
    private float _mass;

    public string spaceshipName { get { return _spaceshipName; } }

    public SpriteView sprite { get { return _sprite; } }

    public float mass { get { return _mass; } }

    public int wins { get { return _wins; } }
}
