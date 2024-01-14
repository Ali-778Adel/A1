using A1.data;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DownloadController(AppDbContext appDbContext) : Controller
{
    [HttpGet("station_image/{stationId}")]
    public IActionResult StationImage(Guid stationId)
    {
        var stationImage = appDbContext
            .Stations
            .Where(x => x.Id == stationId)
            .Select(x => x.Image)
            .FirstOrDefault();
        
         
        if (stationImage == null) return NotFound("no image uploaded for this station");
        
        return File(stationImage, "image/png");
    }
    
    [HttpGet("station_layout/{stationId}")]
    public IActionResult StationLayout(Guid stationId)
    {
        var stationLayout = appDbContext
            .Stations
            .Where(x => x.Id == stationId)
            .Select(x => x.Layout)
            .FirstOrDefault();
        
        if (stationLayout == null) return NotFound("no image uploaded for this station");
        
        return File(stationLayout, "image/png");
    }
}