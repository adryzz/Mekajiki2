namespace Mekajiki2.Types;

public struct Manga
{
    public string Name { get; set; }
    
    public MangaVolume[] Volumes { get; set; }
}