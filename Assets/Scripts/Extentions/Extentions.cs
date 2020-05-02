using System;
using System.Collections.Generic;

public static class Extentions
{
    public static T GetRandom<T>(this List<T> elements)
    {
        return elements[elements.Count > 1 ? UnityEngine.Random.Range(0, elements.Count) : 0];
    }

}
