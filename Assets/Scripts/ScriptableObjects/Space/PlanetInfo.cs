using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Space/Planet")]
public class PlanetInfo : ScriptableObject
{
    [SerializeField]
    private int _wins;

    [SerializeField]
    private string _planetName;

    [SerializeField]
    private SpriteView _surface;

    [SerializeField]
    private SpriteView _sky;

    [SerializeField]
    private SpriteView _icon;

    [SerializeField]
    private float _g;

    public string planetName { get { return _planetName; } }

    public SpriteView surface { get { return _surface; } }

    public SpriteView sky { get { return _sky; } }

    public SpriteView icon { get { return _icon; } }

    public float g { get { return _g; } }

    public int wins { get { return _wins; } }
}
