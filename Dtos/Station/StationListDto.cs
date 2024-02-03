using System.Linq.Expressions;
using A1.Dtos.Company;
using LinqKit;

namespace A1.Dtos.Station;

public class StationListDto
{
    public static Expression<Func<data.Entities.Station, StationListDto>> Mapper()
    {
        return item => new StationListDto()
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
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt,
            Company = item.Company == null ? null : CompanyGetDto.Mapper().Invoke(item.Company)
        };
    }

    public Guid Id { get; set; }
    public bool Active { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string Slug { get; set; }
    public string AddressAr { get; set; }
    public string AddressEn { get; set; }
    public string Lat { get; set; }
    public string Lng { get; set; }
    public bool Solar { get; set; }
    public bool Fuel80 { get; set; }
    public bool Fuel92 { get; set; }
    public bool Fuel95 { get; set; }
    public bool Fuel98 { get; set; }
    public bool EvCharge { get; set; }
    public bool NaturalGas { get; set; }
    public List<string> MoreServices { get; set; }
    public string InvestNumber { get; set; }
    public List<string> ConditionsAr { get; set; }
    public List<string> ConditionsEn { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public CompanyGetDto Company { get; set; }
}