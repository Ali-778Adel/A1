using System.ComponentModel.DataAnnotations;
using A1.data;
using A1.data.Entities;
using A1.Dtos.Unit;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UnitController (AppDbContext appDbContext): Controller
{
  [HttpGet]
  public IActionResult List(int pagSize = 10, int pageNumber = 0, string keyword = "")
  {
    var query = appDbContext.Units.AsQueryable();
    // if (!string.IsNullOrEmpty(keyword))
    // {
    //   query = query.Where(x => x.NameAr.Contains(keyword) || x.NameEn.Contains(keyword));
    // }

    var allUnits = query
      .OrderBy(x => x.UpdatedAt)
      .Skip(pagSize * pageNumber)
      .Take(pagSize)
      .Select(UnitListDto.Mapper())
      .ToList();

    return Ok(allUnits);
  }



  [HttpPost]
  [RequestSizeLimit(long.MaxValue)]
  [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue, ValueLengthLimit = int.MaxValue)]
  public  IActionResult Create([FromForm]UnitCreateDto model)
  {
    if (model == null) return BadRequest("unit must be added ");

    var unit=new Unit();
    

    if (model.Image != null)
    {
      using var ms = new MemoryStream();
      {
        model.Image.CopyTo(ms);
        unit.Image = ms.ToArray();
      }
        
    }
    
    unit.StationId = model.StationId;
    unit.CreatedAt = DateTime.UtcNow;
    unit.UpdatedAt = DateTime.UtcNow;
    unit.Code = model.Code;
    unit.Price = model.Price;
    unit.Size = model.Size;
    unit.Type= model.UnitType;
    unit.NotesAr = model.NoteAr;
    unit.NotesEn = model.NoteEn;
    
    appDbContext.Units.Add(unit);
    appDbContext.SaveChanges();
    return Ok("unit added successfully");
  }


}