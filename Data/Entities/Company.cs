using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A1.data.Entities;

[Table("companies")]
public class Company
{
    [Column("id")] public Guid Id { get; set; }
    [Column("name_ar")] public string NameAr { get; set; }
    [Column("name_en")] public string NameEn { get; set; }
    [Column("slug")] public string Slug { get; set; }
}