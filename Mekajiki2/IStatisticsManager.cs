namespace Mekajiki2;

public interface IStatisticsManager
{
    public int AnimeCount { get; }
    
    public int MangaCount { get; }
    
    public long TotalBytesServed { get; }
}