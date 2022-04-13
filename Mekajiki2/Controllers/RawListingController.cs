using System.Text;
using System.Threading.Tasks;
using Mekajiki2.Types;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mekajiki2.Controllers;

[Route("raw")]
public class RawListingController : ControllerBase
{
    private readonly ILogger<RawListingController> _logger;
    
    private readonly IListingManager _manager;

    private StringBuilder _builder;
    
    public RawListingController(ILogger<RawListingController> logger, IListingManager manager)
    {
        _logger = logger;
        _manager = manager;
        _builder = new StringBuilder();
    }
    
    [HttpGet]
    [Route("anime")]
    public async Task<IActionResult> ListAnime()
    {
        _builder.Clear();
        _builder.Append("<!DOCTYPE html><html><head><title>");
        _builder.Append("Anime Listing");
        _builder.Append("</title></head><body>");
        
        for (int i = 0; i < _manager.AnimeListing.Count; i++)
        {
            _builder.Append($"<a href=\"{Request.GetEncodedUrl()}/{i}\">{_manager.AnimeListing[i].Name}</a><br>");
        }

        _builder.Append("</body></html>");
        return Content(_builder.ToString(), "text/html");
    }
    
    [HttpGet]
    [Route("anime/{series}")]
    public async Task<IActionResult> ListAnimeEpisodes(int series)
    {
        if (series > _manager.AnimeListing.Count || series < 0)
            return NotFound();

        Anime a = _manager.AnimeListing[series];
        
        _builder.Clear();
        _builder.Append("<!DOCTYPE html><html><head><title>");
        _builder.Append(a.Name);
        _builder.Append("</title></head><body>");
        
        for (int i = 0; i < a.Episodes.Length; i++)
        {
            _builder.Append($"<a href=\"/api/anime/{series}/{i}\">Episode {i}</a><br>");
        }

        _builder.Append("</body></html>");
        return Content(_builder.ToString(), "text/html");
    }
    
    [HttpGet]
    [Route("manga")]
    public async Task<IActionResult> ListManga()
    {
        _builder.Clear();
        _builder.Append("<!DOCTYPE html><html><head><title>");
        _builder.Append("Manga Listing");
        _builder.Append("</title></head><body>");
        
        for (int i = 0; i < _manager.MangaListing.Count; i++)
        {
            _builder.Append($"<a href=\"{Request.GetEncodedUrl()}/{i}\">{_manager.MangaListing[i].Name}</a><br>");
        }

        _builder.Append("</body></html>");
        return Content(_builder.ToString(), "text/html");
    }
    
    [HttpGet]
    [Route("manga/{series}")]
    public async Task<IActionResult> ListMangaVolumes(int series)
    {
        if (series > _manager.MangaListing.Count || series < 0)
            return NotFound();

        Manga m = _manager.MangaListing[series];
        
        _builder.Clear();
        _builder.Append("<!DOCTYPE html><html><head><title>");
        _builder.Append(m.Name);
        _builder.Append("</title></head><body>");
        
        for (int i = 0; i < m.Volumes.Length; i++)
        {
            _builder.Append($"<a href=\"/api/manga/{series}/{i}\">Volume {i}</a><br>");
        }

        _builder.Append("</body></html>");
        return Content(_builder.ToString(), "text/html");
    }
}