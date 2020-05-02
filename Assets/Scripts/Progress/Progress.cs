using System;
using Newtonsoft.Json;

public class Progress
{
    [JsonProperty("Space")]
    public Points space;

    [JsonProperty("Plane")]
    public Points plane;
}

public class Points
{
    [JsonProperty("wins")]
    public int wins;

    [JsonProperty("looses")]
    public int looses;

    [JsonConstructor]
    public Points(int wins, int looses)
    {
        this.wins = wins;
        this.looses = looses;
    }
}
