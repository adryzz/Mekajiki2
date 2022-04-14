using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mekajiki2.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mekajiki2.Controllers;

[Area("api")]
[Route("[area]/manga")]
public class MangaListingController : ControllerBase
{
    private readonly ILogger<MangaListingController> _logger;
    
    private readonly IListingManager _listing;
    
    public MangaListingController(ILogger<MangaListingController> logger, IListingManager listing)
    {
        _logger = logger;
        _listing = listing;
    }
    
    [HttpGet]
    [Route("list")]
    public async Task<IEnumerable<Manga>> List()
    {
        return _listing.MangaListing;
    }
    
    [HttpGet]
    [Route("{series}/{volume}")]
    public async Task<IActionResult> Get(int series, int volume)
    {
        if (series >= _listing.MangaListing.Count || series < 0)
            return NotFound();
        
        var s = _listing.MangaListing[series];
        
        if (volume >= s.Volumes.Length || volume < 0)
            return NotFound();
        
        
        var vol = s.Volumes[volume];
        
        if (!System.IO.File.Exists(vol.FilePath))
            return NoContent();
        
        return PhysicalFile(vol.FilePath, "application/octet-stream", $"{s.Name}-{volume}{Path.GetExtension(vol.FilePath)}", true);
    }
    
    [HttpGet]
    [Route("search")]
    public async Task<IEnumerable<Manga>> Search([FromQuery] string query)
    {
        return _listing.MangaListing.Where(x => x.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
    }
}