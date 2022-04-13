using System;
using System.Text.Json.Serialization;

namespace Mekajiki2.Types;

public struct AnimeEpisode
{
    [JsonIgnore]
    public string FilePath { get; set; }
    
    public TimeSpan Duration { get; set; }

    public Resolution Resolution { get; set; }
}