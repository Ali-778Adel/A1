using System.ComponentModel.DataAnnotations;
using A1.data;
using A1.data.Entities;
using A1.Dtos.Company;
using A1.Resources.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;


namespace A1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CompanyController : Controller
{
    private readonly AppDbContext _appDbContext;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public CompanyController(AppDbContext appDbContext, IStringLocalizer<SharedResource> localizer)
    {
        _appDbContext = appDbContext;
        _localizer = localizer;
    }

    [HttpGet("localize")]
    public IActionResult Localize()
    {
        return Ok(_localizer["server_running"].Value);
    }

    [HttpGet("get_all_companies")]
    public IActionResult List(string keyword="")
    {
        var query = _appDbContext.Companies.AsQueryable();
        Console.WriteLine(query);
        if (!string.IsNullOrEmpty(keyword))
        {
             query = query.Where(c => c.NameAr.Contains(keyword)|| c.NameEn.Contains(keyword));
        }

        var allCompanies = query.OrderBy(c => c.UpdatedAt)
            .Select((CompanyListDto.Mapper))
            .ToList();

        return Ok(allCompanies);
    }

    [HttpGet("get_company/{id}")] //route only 
    public IActionResult Get(Guid id) //query parameter
    {
        var quary = _appDbContext.Companies.Where(x=>x.Id==id);

        var company =
            quary.Select(CompanyGetDto.Mapper()).FirstOrDefault(x => x.Id == id);
            

        if (company == null) return NotFound();

        return Ok(company);
    }
    
    [HttpPost("add_company")]

    public IActionResult Create([FromForm]CompanyCreateDto companyCreateDto)
    {
        CreateOrUpdate(companyCreateDto);
        return Ok("company created successfully");
    }


    [HttpPut("update_company")]
    public IActionResult Update([FromForm]CompanyEditDto companyEditDto)
    {
        CreateOrUpdate(companyEditDto);
        
        return Ok("item updated successfully");
    }

    public bool CreateOrUpdate(CompanyCreateDto model)
    {
        Company company; 
        if (model is CompanyEditDto companyEditDto)
        {
            company = _appDbContext.Companies.FirstOrDefault(x=>x.Id==companyEditDto.Id);
            if (company == null) return false;
        }
        else
        {
            company = new Company();
            _appDbContext.Companies.Add(company);
        }

        company.NameAr = model.NameAr;
        company.NameEn = model.NameEn;
        company.Slug = model.Slug;
        if (model is CompanyEditDto )
        {
            company.UpdatedAt = DateTime.UtcNow;    
        }
        else
        {
            company.CreatedAt = DateTime.UtcNow;
            company.UpdatedAt = DateTime.UtcNow;    
        }
        
        _appDbContext.SaveChanges();
        return true;
    }


[HttpDelete("delete_company/{id}")]
    public IActionResult Delete(Guid id)
    {
        var item = _appDbContext.Companies.Find(id);
        Console.WriteLine(item);      
        if (item == null) return NotFound("item not found");
        
        _appDbContext.Companies.Remove(item);
        _appDbContext.SaveChanges();
        return Ok($"Item deleted successfully{item}");
    }

}

