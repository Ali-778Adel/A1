using System.Reflection;
using A1.data;
using A1.data.Entities;
using A1.Dtos.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Web;


namespace A1.Controllers;


[ApiController]
[Route("api/stations")]
public class StationsController(AppDbContext appDbContext) : Controller
{
    private readonly AppDbContext _appDbContext = appDbContext;

    [HttpGet("get_all_stations")]
   public IActionResult GetStations()
   {
      var allStations= _appDbContext.Stations.ToList();
        return Ok(allStations);
    }

   
   [HttpGet]
   [Route("get_station_by_id")]
    public IActionResult GetStation(Guid id)
    {
        DbSet<Station> stationEntities = _appDbContext.Stations;     
        return Ok(stationEntities);
    }


    [HttpPost]
    [Route("add_station")]

    public IActionResult PostStation(StationListDto stationListDto)
    {
        try
        {

            
         
            _appDbContext.Stations.Add(new Station
            {
                Active = stationListDto.Active,
                Company = stationListDto.Company,
                NameAr = stationListDto.NameAr,
                NameEn = stationListDto.NameEn,
                Slug = stationListDto.Slug,
                Image =stationListDto.Image,
                AddressAr = stationListDto.AddressAr,
                AddressEn = stationListDto.AddressEn,
                Lat = stationListDto.Lat,
                Lng = stationListDto.Lng,
                Solar = stationListDto.Solar,
                Fuel80 = stationListDto.Fuel80,
                Fuel92 = stationListDto.Fuel92,
                Fuel95 = stationListDto.Fuel95,
                Fuel98 = stationListDto.Fuel98,
                EvCharge = stationListDto.EvCharge,
                NaturalGas = stationListDto.NaturalGas,
                MoreServices = stationListDto.MoreServices,
                InvestNumber = stationListDto.InvestNumber,
                ConditionsAr = stationListDto.ConditionsAr,
                ConditionsEn = stationListDto.ConditionsEn,
                LayoutUrl = stationListDto.LayoutUrl,
            });
            _appDbContext.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine("exception on station create method $e");
            throw;
        }
        
        
    }
}

