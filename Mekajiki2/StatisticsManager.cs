namespace Mekajiki2;

public class StatisticsManager : IStatisticsManager
{
    private readonly IConfigurationManager _configuration;
    
    private readonly IListingManager _listing;

    public StatisticsManager(IConfigurationManager configuration, IListingManager listing)
    {
        _configuration = configuration;
        _listing = listing;
    }

    public int AnimeCount => _listing.AnimeListing.Count;

    public int MangaCount => _listing.MangaListing.Count;

    public long TotalBytesServed => 0;
}