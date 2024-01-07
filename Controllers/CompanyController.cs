using System.ComponentModel.DataAnnotations;
using A1.data;
using A1.data.Entities;
using A1.Dtos.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace A1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CompanyController : Controller
{
    private readonly AppDbContext _appDbContext;

    public CompanyController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet("get_all_companies")]
    public IActionResult List()
    {
        var companies = _appDbContext.Companies.ToList();
        Console.WriteLine(companies);
        return Ok(companies);
    }

    [HttpGet("{id:guid}")] //route only 
    public IActionResult Get(Guid id) //query parameter
    {
        return Ok();
    }


    [HttpPost("add_company")]
    public IActionResult Create([FromBody] CompanyListDto companyCto)
    {
        if (companyCto is null)
        {
            return BadRequest("Company object is null");
        }

        try
        {

            var result= _appDbContext.Companies.Add(new Company{
                NameAr = companyCto.NameAr,
                NameEn = companyCto.NameEn,
                Slug = companyCto.Slug});
            _appDbContext.SaveChanges();

            return Ok(result);
        }
        catch (Exception e)
        
        {
            // Check if it's a duplicate key violation
            Console.WriteLine(e);

            // Handle other types of exceptions
            return BadRequest($"Error adding company: {e.Message}");
        }
    }

}

