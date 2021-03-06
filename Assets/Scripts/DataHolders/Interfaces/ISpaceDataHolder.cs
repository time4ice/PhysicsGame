﻿using System;
using System.Collections.Generic;

public interface ISpaceDataHolder
{
    PlanetInfo GetRandomPlanet(int wins);

    PlanetInfo GetPlanet(string name);

    List<PlanetInfo> GetPlanets();

    SpaceshipInfo GetRandomSpaceship(int wins);

    SpaceshipInfo GetSpaceship(string name);

    float GetMinSpaceshipMass();

    List<SpaceshipInfo> GetSpaceships();

    SpaceInfo GetSpaceInfo();

    float GetMinG();
}
