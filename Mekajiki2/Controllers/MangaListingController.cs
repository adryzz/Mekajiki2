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
    
    private readonly IListingManager _manager;
    
    public MangaListingController(ILogger<MangaListingController> logger, IListingManager manager)
    {
        _logger = logger;
        _manager = manager;
    }
    
    [HttpGet]
    [Route("list")]
    public async Task<IEnumerable<Manga>> List()
    {
        return _manager.MangaListing;
    }
    
    [HttpGet]
    [Route("{series}/{volume}")]
    public async Task<IActionResult> Get(int series, int volume)
    {
        if (series >= _manager.MangaListing.Count || series < 0)
            return NotFound();
        
        var s = _manager.MangaListing[series];
        
        if (volume >= s.Volumes.Length || volume < 0)
            return NotFound();
        
        
        var vol = s.Volumes[volume];
        
        return PhysicalFile(vol.FilePath, "application/octet-stream", $"{s.Name}-{volume}{Path.GetExtension(vol.FilePath)}", true);
    }
    
    [HttpGet]
    [Route("search")]
    public async Task<IEnumerable<Manga>> Search([FromQuery] string query)
    {
        return _manager.MangaListing.Where(x => x.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
    }
}