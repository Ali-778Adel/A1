using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace A1.data.Entities;

[Table(("stations"))]
public class Station
{
    [Column(("id"))] public Guid Id { get; set; }
    [Column(("active"))] public bool Active { get; set; }
    [MaxLength(255)] [Column(("name_ar"))] public string NameAr { get; set; }
    [MaxLength(255)] [Column(("name_en"))] public string NameEn { get; set; }
    [MaxLength(255)] [Column(("slug"))] public string Slug { get; set; }

    [Column(("image"))] public byte[] Image { get; set; }

    [MaxLength(255)]
    [Column(("address_ar"))]
    public string AddressAr { get; set; }

    [MaxLength(255)]
    [Column(("address_en"))]
    public string AddressEn { get; set; }

    [MaxLength(255)] [Column(("lat"))] public string Lat { get; set; }
    [MaxLength(255)] [Column(("lng"))] public string Lng { get; set; }
    [Column(("solar"))] public bool Solar { get; set; }
    [Column(("fuel80"))] public bool Fuel80 { get; set; }
    [Column(("fuel92"))] public bool Fuel92 { get; set; }
    [Column(("fuel95"))] public bool Fuel95 { get; set; }
    [Column(("fuel98"))] public bool Fuel98 { get; set; }

    [Column(("ev_charge"))] public bool EvCharge { get; set; }
    [Column(("natural_gaz"))] public bool NaturalGas { get; set; }

    [Column(("layout"))] public byte[] Layout { get; set; }

    [MaxLength(255)]
    [Column(("invest_number"))]
    public string InvestNumber { get; set; }

    [Column(("more_services"))] public List<string> MoreServices { get; set; }
    [Column(("conditions_ar"))] public List<string> ConditionsAr { get; set; }

    [Column(("conditions_en"))] public List<string> ConditionsEn { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    [Column(("company"))]
    [ForeignKey(nameof(CompanyId))]
    public virtual Company Company { get; set; }

    [Column(("company_id"))] public Guid CompanyId { get; set; }
}