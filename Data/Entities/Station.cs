using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace A1.data.Entities;


[Table(("stations"))]
public class Station
{
    [Column(("id"))]
    public Guid Id { get; set; }
    [Column(("active"))]
    public bool Active { get; set; }
    [Column(("company"))]
    public Company Company { get; set; }
    [Column(("name_ar"))]
    public string NameAr { get; set; }
    [Column(("name_en"))]
    public string NameEn { get; set; }
    [Column(("slug"))]
    public string Slug { get; set; }
    [Column(("image"))]
    public byte Image { get; set; }
    [Column(("address_ar"))]
    public string AddressAr { get; set; }
    [Column(("address_en"))]
    public string AddressEn { get; set; }
    [Column(("lat"))]
    public string Lat { get; set; }
    [Column(("lng"))]
    public string Lng { get; set; }
    [Column(("solar"))]
    public bool Solar { get; set; }
    [Column(("fuel80"))]
    public bool Fuel80{ get; set; }
    [Column(("fuel92"))]
    public bool Fuel92 { get; set; }
    [Column(("fuel95"))]
    public bool Fuel95 { get; set; }
    [Column(("fuel98"))]
    public bool Fuel98 { get; set; }
    [Column(("ev_charge"))]
    public bool EvCharge { get; set; }
    [Column(("natural_gaz"))]
    public bool NaturalGas { get; set; }
    [Column(("more_services"))]
    public List<string> MoreServices { get; set; }
    [Column(("invest_number"))]
    public string InvestNumber { get; set; }
    [Column(("conditions_ar"))]
    public List<string> ConditionsAr { get; set; }
    [Column(("conditions_en"))]
    public List<string> ConditionsEn { get; set; }
    [Column(("layout_url"))]
    public string LayoutUrl { get; set; }
}