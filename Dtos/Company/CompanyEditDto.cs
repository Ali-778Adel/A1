using System.Linq.Expressions;

namespace A1.Dtos.Company;

public class CompanyEditDto : CompanyCreateDto
{
    public static Expression<Func<data.Entities.Company, CompanyEditDto>> Mapper => item => new CompanyEditDto()
    {
        Id = item.Id
    };

    public Guid Id { get; set; }
}