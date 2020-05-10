using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpaceDataHolder:ISpaceDataHolder
{
    private List<PlanetInfo> _planets=new List<PlanetInfo>();

    private List<SpaceshipInfo> _spaceShips = new List<SpaceshipInfo>();

    private SpaceInfo _spaceInfo;

    public SpaceDataHolder()
    {
        LoadAssets();
    }

    public PlanetInfo GetRandomPlanet(int wins)
    {
        return _planets.Where(s => s.wins <= wins).ToList().GetRandom();
    }

    public PlanetInfo GetPlanet(string name)
    {
        return _planets.FirstOrDefault(p => p.name == name);
    }

    public List<PlanetInfo> GetPlanets()
    {
        return _planets.OrderBy(p => p.wins).ToList();
    }

    public SpaceshipInfo GetRandomSpaceship(int wins)
    {
        return _spaceShips.Where(s=>s.wins<=wins).ToList().GetRandom();
    }

    public SpaceshipInfo GetSpaceship(string name)
    {
        return _spaceShips.FirstOrDefault(s => s.name == name);
    }
    public List<SpaceshipInfo> GetSpaceships()
    {
        return _spaceShips.OrderBy(s => s.wins).ToList();
    }

    public SpaceInfo GetSpaceInfo()
    {
        return _spaceInfo;
    }

    private void LoadAssets()
    {
        foreach (PlanetInfo conf in Resources.LoadAll("Planets", typeof(PlanetInfo)))
        {
            _planets.Add(conf);
        }
     
        foreach (SpaceshipInfo conf in Resources.LoadAll("Spaceships", typeof(SpaceshipInfo)))
        {
            _spaceShips.Add(conf);
        }
       
        _spaceInfo = (SpaceInfo) Resources.Load("SpaceInfo", typeof(SpaceInfo));
    }
}
