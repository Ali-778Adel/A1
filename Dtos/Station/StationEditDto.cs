using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace A1.Dtos.Station;

public class StationEditDto : StationCreateDto
{
    public static Expression<Func<data.Entities.Station, StationEditDto>> Mapper => item => new StationEditDto()
    {
        Id = item.Id,
        Active = item.Active,
        NameAr = item.NameAr,
        NameEn = item.NameEn,
        Slug = item.Slug,
        AddressAr = item.AddressAr,
        AddressEn = item.AddressEn,
        Lat = item.Lat,
        Lng = item.Lng,
        Solar = item.Solar,
        Fuel80 = item.Fuel80,
        Fuel92 = item.Fuel92,
        Fuel95 = item.Fuel95,
        Fuel98 = item.Fuel98,
        EvCharge = item.EvCharge,
        NaturalGas = item.NaturalGas,
        ConditionsAr = item.ConditionsAr,
        ConditionsEn = item.ConditionsEn,
        MoreServices = item.MoreServices,
        InvestNumber = item.InvestNumber,
    };

    [Required] public Guid? Id { get; set; }
}