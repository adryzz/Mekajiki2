using System;
using System.Text.Json.Serialization;

namespace Mekajiki2.Types;

public struct AnimeEpisode
{
    [JsonIgnore]
    public string FilePath { get; set; }
    
    public TimeSpan Duration { get; set; }

    public (uint Width, uint Height) Resolution { get; set; }
}