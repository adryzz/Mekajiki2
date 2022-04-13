using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mekajiki2.Controllers;

[Area("api")]
[Route("[area]/[controller]")]
public class SshController : ControllerBase
{
    private readonly ILogger<SshController> _logger;
    
    private readonly IListingManager _manager;
    
    public SshController(ILogger<SshController> logger, IListingManager manager)
    {
        _logger = logger;
        _manager = manager;
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task Enable()
    {
        
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task Disable()
    {
        
    }
    
    [HttpPost]
    [Route("[action]")]
    public async Task Configure()
    {
        
    }
}