using System;
using System.Collections.Generic;
using Mekajiki2.Types;

namespace Mekajiki2;

public class ListingManager : IListingManager
{
    private readonly IConfigurationManager _config;
    
    public ListingManager(IConfigurationManager config)
    {
        _config = config;
    }

    public List<Anime> AnimeListing { get; }
    public List<Manga> MangaListing { get; }
}