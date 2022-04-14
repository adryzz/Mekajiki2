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
[Route("[area]/anime")]
public class AnimeListingController : ControllerBase
{
    private readonly ILogger<AnimeListingController> _logger;
    
    private readonly IListingManager _listing;
    
    public AnimeListingController(ILogger<AnimeListingController> logger, IListingManager listing)
    {
        _logger = logger;
        _listing = listing;
    }
    
    [HttpGet]
    [Route("list")]
    public async Task<IEnumerable<Anime>> List()
    {
        return _listing.AnimeListing;
    }
    
    [HttpGet]
    [Route("{series}/{episode}")]
    public async Task<IActionResult> Get(int series, int episode)
    {
        if (series >= _listing.AnimeListing.Count || series < 0)
            return NotFound();
        
        var s = _listing.AnimeListing[series];
        
        if (episode >= s.Episodes.Length || episode < 0)
            return NotFound();
        
        var ep = s.Episodes[episode];

        if (!System.IO.File.Exists(ep.FilePath))
            return NoContent();
        
        return PhysicalFile(ep.FilePath, "application/octet-stream", $"{s.Name}-{episode}{Path.GetExtension(ep.FilePath)}", true);
    }
    
    [HttpGet]
    [Route("search")]
    public async Task<IEnumerable<Anime>> Search([FromQuery] string query)
    {
        return _listing.AnimeListing.Where(x => x.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
    }
}