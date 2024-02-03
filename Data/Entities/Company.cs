using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A1.data.Entities;

[Table("companies")]
public class Company
{
    [Column("id")] public Guid Id { get; set; }
    [MaxLength(255)] [Column("name_ar")] public string NameAr { get; set; }
    [MaxLength(255)] [Column("name_en")] public string NameEn { get; set; }
    [MaxLength(255)] [Column("slug")] public string Slug { get; set; }

    [MaxLength(255)]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [MaxLength(255)]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}