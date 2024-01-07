using A1.data;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DownloadController(AppDbContext appDbContext) : Controller
{
    [HttpGet("station-image/{stationId}")]
    public IActionResult StationImage(Guid stationId)
    {
        var stationImage = appDbContext
            .Stations
            .Where(x => x.Id == stationId)
            .Select(x => x.Image)
            .FirstOrDefault();
        
        if (stationImage == null) return NotFound();
        
        return File(stationImage, "image/jpeg");
    }
    
    [HttpGet("station-layout/{stationId}")]
    public IActionResult StationLayout(Guid stationId)
    {
        var stationImage = appDbContext
            .Stations
            .Where(x => x.Id == stationId)
            .Select(x => x.Layout)
            .FirstOrDefault();
        
        if (stationImage == null) return NotFound();
        
        return File(stationImage, "image/jpeg");
    }
}