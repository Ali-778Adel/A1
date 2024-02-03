using System.Linq.Expressions;

namespace A1.Dtos.Company;

public class CompanyGetDto
{
    public static Expression<Func<data.Entities.Company, CompanyGetDto>> Mapper()
    {
        return item => new CompanyGetDto()
        {
            Id = item.Id,
            NameAr = item.NameAr,
            NameEn = item.NameEn,
            Slug = item.Slug,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt,
        };
    }

    public Guid Id { get; set; }

    public string NameAr { get; set; }

    public string NameEn { get; set; }

    public string Slug { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}