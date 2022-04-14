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
        AnimeListing.Add(new Anime
        {
            Name = "Cock",
            Episodes = new []
            {
                new AnimeEpisode
                {
                    Duration = TimeSpan.FromSeconds(69),
                    FilePath = "/mnt/adryzz/アニメ/Shakugan No Shana/Season 1/EP.1.720p.mp4",
                    Resolution = new Resolution(1280, 720)
                },
                new AnimeEpisode
                {
                    Duration = TimeSpan.FromSeconds(420),
                    FilePath = "/mnt/adryzz/アニメ/Shakugan No Shana/Season 1/EP.2.720p.mp4",
                    Resolution = new Resolution(1920, 1080)
                }
            }
        });
    }

    public List<Anime> AnimeListing { get; private set; }
    public List<Manga> MangaListing { get; private set; }
}