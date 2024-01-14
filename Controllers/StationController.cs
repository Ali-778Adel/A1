using A1.data;
using A1.data.Entities;
using Microsoft.AspNetCore.Mvc;
using A1.Dtos.Station;
namespace A1.Controllers;

[ApiController]
[Route("api/stations")]
public class StationsController(AppDbContext appDbContext) : Controller
{
    [HttpGet("get_all_stations")]
    public IActionResult List(int pagSize = 10, int pageNumber = 0, string keyword = "")
    {
        var query = appDbContext.Stations.AsQueryable();
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.NameAr.Contains(keyword) || x.NameEn.Contains(keyword));
        }

        var allStations = query
            .OrderBy(x => x.UpdatedAt)
            .Skip(pagSize * pageNumber)
            .Take(pagSize)
            .Select(StationListDto.Mapper).ToList();

        return Ok(allStations);
    }


    [HttpGet("get_station/{id}")]
    public IActionResult Get(Guid id)
    {
        var station =
             appDbContext.Stations.Select(StationGetDto.Mapper).FirstOrDefault(x => x.Id == id);
        if (station == null) return NotFound();
        return Ok(station);
    }


    [HttpPost("create_station")]
    [RequestSizeLimit(long.MaxValue)]
    public IActionResult Create([FromForm] StationCreateDto model)
    {
        var isSuccess = CreateOrUpdate(model);
        if (!isSuccess) return BadRequest();
        return Ok("station created successfully");
    }
    
    [HttpPut("update_station")]
    public IActionResult Update([FromForm] StationEditDto model)
    {
        var isSuccess = CreateOrUpdate(model);
        if (!isSuccess) return BadRequest();
        return Ok("station updated successfully");
    }

    [HttpDelete("delete_station/{id}")]
    public IActionResult Delete(Guid id)
    {
        var item = appDbContext.Stations.Find(id);
        if (item == null) return NotFound();
        appDbContext.Stations.Remove(item);
        appDbContext.SaveChanges();
        return Ok("station deleted successfully");
    }
    
    
/// <summary>
/// it made to as shared object pattern to be done depending its model
/// create or update logic 
/// </summary>
/// <param name="model"></param>
/// <returns></returns>
    public bool CreateOrUpdate(StationCreateDto model)
    {
        Station station;
        if (model is StationEditDto stationEditDto)
        {
            station = appDbContext.Stations.FirstOrDefault(x => x.Id == stationEditDto.Id);
            if (station == null) return false;
        }
        else
        {
            station = new Station();
            appDbContext.Stations.Add(station);
        }
    
        if (model.Image != null)
        {
            using var ms = new MemoryStream();
            model.Image.CopyTo(ms);
            station.Image = ms.ToArray();
        }
        
        if (model.Layout != null)
        {
            using var ms = new MemoryStream();
            model.Layout.CopyTo(ms);
            station.Layout = ms.ToArray();
           
        }
    
        station.Active = model.Active;
        station.NameAr = model.NameAr;
        station.NameEn = model.NameEn;
        station.Slug = model.Slug;
        station.AddressAr = model.AddressAr;
        station.AddressEn = model.AddressEn;
        station.Lat = model.Lat;
        station.Lng = model.Lng;
        station.Solar = model.Solar;
        station.Fuel80 = model.Fuel80;
        station.Fuel92 = model.Fuel92;
        station.Fuel95 = model.Fuel95;
        station.Fuel98 = model.Fuel98;
        station.EvCharge = model.EvCharge;
        station.NaturalGas = model.NaturalGas;
        station.ConditionsAr = model.ConditionsAr;
        station.ConditionsEn = model.ConditionsEn;
        station.MoreServices = model.MoreServices;
        station.InvestNumber = model.InvestNumber;
        station.CompanyId = model.CompanyId;
        
            
        station.Company = appDbContext.Companies.FirstOrDefault(c=>c.Id==model.CompanyId);

        if (model is StationEditDto)
        {
            station.UpdatedAt = DateTime.UtcNow;
        }
        else
        {
            station.CreatedAt = DateTime.UtcNow;
            station.UpdatedAt = DateTime.UtcNow;   
        }


        appDbContext.SaveChanges();
        
        return true;
    }
}