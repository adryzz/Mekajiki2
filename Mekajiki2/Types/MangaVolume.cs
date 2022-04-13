using System.Text.Json.Serialization;

namespace Mekajiki2.Types;

public struct MangaVolume
{
    [JsonIgnore]
    public string FilePath { get; set; }
    
    public uint Pages { get; set; }
}