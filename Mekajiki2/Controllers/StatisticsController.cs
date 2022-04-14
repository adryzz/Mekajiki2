using System.Threading.Tasks;
using Mekajiki2.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mekajiki2.Controllers;

[Area("api")]
[Route("[area]/stats")]
public class StatisticsController : ControllerBase
{
    private readonly ILogger<StatisticsController> _logger;
    
    private readonly IStatisticsManager _stats;
    
    public StatisticsController(ILogger<StatisticsController> logger, IStatisticsManager stats)
    {
        _logger = logger;
        _stats = stats;
    }
    
    [HttpGet]
    public async Task<ServerStatistics> Stats()
    {
        return new ServerStatistics
        {
            AnimeCount = _stats.AnimeCount,
            MangaCount = _stats.MangaCount,
            TotalBytesServed = _stats.TotalBytesServed
        };
    }
}