using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using A1.data.Abstraction;

namespace A1.data.Entities;

[Table("units")]
public class Unit : DeletableEntity
{
    [Column("code")] public int Code { get; set; }

    [Column("size")] public string Size { get; set; }

    [Column("price")] public string Price { get; set; }

    [Column("note_ar")] public List<string> NotesAr { get; set; }

    [Column("note_en")] public List<string> NotesEn { get; set; }

    [Column("station_id")] public Guid StationId { get; set; }

    [Column("type")] public string Type { get; set; }
    [Column("image")] public byte[] Image { get; set; }

    [Column("station")]
    [ForeignKey(nameof(StationId))]
    public Station Station { get; set; }
}