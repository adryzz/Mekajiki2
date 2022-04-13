using System;
using System.Collections.Generic;
using System.Drawing;
using Mekajiki2.Types;

namespace Mekajiki2;

public class ListingManager : IListingManager
{
    private readonly IConfigurationManager _config;
    
    public ListingManager(IConfigurationManager config)
    {
        _config = config;
        AnimeListing = new List<Anime>();
        MangaListing = new List<Manga>();
    }

    public List<Anime> AnimeListing { get; private set; }
    public List<Manga> MangaListing { get; private set; }
}