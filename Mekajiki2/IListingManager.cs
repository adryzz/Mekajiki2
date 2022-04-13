using System.Collections.Generic;
using Mekajiki2.Types;

namespace Mekajiki2;

public interface IListingManager
{
    public List<Anime> AnimeListing { get; }
    
    public List<Manga> MangaListing { get; }
}