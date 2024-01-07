using System.Reflection;
using A1.data;
using A1.data.Entities;
using A1.Dtos.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Web;
using A1.Dtos.Station;


namespace A1.Controllers;

[ApiController]
[Route("api/stations")]
public class StationsController(AppDbContext appDbContext) : Controller
{
    [HttpGet]
    public IActionResult List(int pagSize = 10, int pageNumber = 0, string keyword = "")
    {
        throw new Exception("test");
        var query = appDbContext.Stations.AsQueryable();
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.NameAr.Contains(keyword) || x.NameEn.Contains(keyword));
        }

        var allStations = query
            .OrderBy(x => x.Id)
            .Skip(pagSize * pageNumber)
            .Take(pagSize)
            .Select(StationListDto.Mapper).ToList();

        return Ok(allStations);
    }


    [HttpGet("{id}")]
    public IActionResult Get(Guid id, bool forEdit)
    {
        var station = forEdit
            ? appDbContext.Stations.Select(StationEditDto.Mapper).FirstOrDefault(x => x.Id == id) as object
            : appDbContext.Stations.Select(StationGetDto.Mapper).FirstOrDefault(x => x.Id == id);

        if (station == null) return NotFound();
        return Ok(station);
    }


    [HttpPost]
    public IActionResult Create([FromForm] StationCreateDto model)
    {
        var isSuccess = CreateOrUpdate(model);
        if (!isSuccess) return BadRequest();
        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromForm] StationEditDto model)
    {
        var isSuccess = CreateOrUpdate(model);
        if (!isSuccess) return BadRequest();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var item = appDbContext.Stations.Find(id);
        if (item == null) return NotFound();
        appDbContext.Stations.Remove(item);
        appDbContext.SaveChanges();
        return Ok();
    }

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

        appDbContext.SaveChanges();
        return true;
    }
}