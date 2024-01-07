using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace A1.Dtos.Company;

public class CompanyListDto
{
    public static Expression<Func<data.Entities.Company, CompanyListDto>> Mapper => item => new CompanyListDto()
    {
        Id = item.Id,
        NameAr = item.NameAr,
        NameEn = item.NameEn,
        Slug = item.Slug,
    };

    public Guid Id { get; set; }
    [Required] public string NameAr { get; set; }
    [Required] public string NameEn { get; set; }
    [Required] public string Slug { get; set; }
}