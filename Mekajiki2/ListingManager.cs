using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using Mekajiki2.Types;

namespace Mekajiki2;

public class ListingManager : IListingManager
{
    private readonly IConfigurationManager _config;
    
    public ListingManager(IConfigurationManager config)
    {
        _config = config;
        if (File.Exists(_config.Current.AnimeListingPath))
        {
            using (Stream fs = File.OpenRead(_config.Current.AnimeListingPath))
            {
                AnimeListing = JsonSerializer.Deserialize<List<Anime>>(fs) ?? new List<Anime>();
            }
        }
        else
        {
            AnimeListing = new List<Anime>();
        }
        
        if (File.Exists(_config.Current.MangaListingPath))
        {
            using (Stream fs = File.OpenRead(_config.Current.MangaListingPath))
            {
                MangaListing = JsonSerializer.Deserialize<List<Manga>>(fs) ?? new List<Manga>();
            }
        }
        else
        {
            MangaListing= new List<Manga>();
        }
    }

    public List<Anime> AnimeListing { get; private set; }
    public List<Manga> MangaListing { get; private set; }
}