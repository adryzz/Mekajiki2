using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mekajiki2.Controllers;

[Route("raw")]
public class RawListingController : ControllerBase
{
    private readonly ILogger<RawListingController> _logger;
    
    private readonly IListingManager _manager;
    
    public RawListingController(ILogger<RawListingController> logger, IListingManager manager)
    {
        _logger = logger;
        _manager = manager;
    }
    
    [HttpGet]
    [Route("anime")]
    public async Task ListAnime()
    {
        
    }
    
    [HttpGet]
    [Route("anime/{series}")]
    public async Task ListAnimeEpisodes(uint series)
    {
        
    }
    
    [HttpGet]
    [Route("manga")]
    public async Task ListManga()
    {
        
    }
    
    [HttpGet]
    [Route("manga/{series}")]
    public async Task ListMangaVolumes(uint series)
    {
        
    }
}