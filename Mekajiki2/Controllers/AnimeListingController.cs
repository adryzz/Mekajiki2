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
    
    private readonly IListingManager _manager;
    
    public AnimeListingController(ILogger<AnimeListingController> logger, IListingManager manager)
    {
        _logger = logger;
        _manager = manager;
    }
    
    [HttpGet]
    [Route("list")]
    public async Task<IEnumerable<Anime>> List()
    {
        return _manager.AnimeListing;
    }
    
    [HttpGet]
    [Route("{series}/{episode}")]
    public async Task<IActionResult> Get(int series, uint episode)
    {
        var s = _manager.AnimeListing[series];
        var ep = s.Episodes[episode];
        
        return PhysicalFile(ep.FilePath, "application/octet-stream", $"{s.Name}-{episode}{Path.GetExtension(ep.FilePath)}", true);
    }
    
    [HttpGet]
    [Route("search")]
    public async Task<IEnumerable<Anime>> Search([FromQuery] string query)
    {
        return _manager.AnimeListing.Where(x => x.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
    }
}