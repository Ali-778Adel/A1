using System.ComponentModel.DataAnnotations;

namespace A1.Dtos.Station;

public class StationCreateDto
{
    [Required(ErrorMessage = "Active is required")]
    public bool Active { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string Slug { get; set; }
    public Guid CompanyId { get; set; }
    public IFormFile Image { get; set; }
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
    public IFormFile Layout { get; set; }

    
}