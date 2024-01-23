using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A1.data.Entities;


[Table("units")]
public class Unit
{
   
  [Column("id")]  public Guid Id { get; set; }

 [Column("code")]   public int  Code { get; set; }
 
 [Column("size")]    public string  Size { get; set; }

 [Column("price")]    public string Price { get; set; }
    
 [Column("note_ar")]    public List<string> NotesAr { get; set; }

 [Column("note_en")]    public List<string> NotesEn { get; set; }
    
 [Column("station_id")]     public Guid StationId { get; set; }

 [Column("type")]     public string Type { get; set; }
 [Column("image")]    public byte[] Image { get; set; }

 [Column("created_at")]     public DateTime CreatedAt { get; set; }

 [Column("updated_at")]     public DateTime UpdatedAt { get; set; }

 [Column("station")]
 [ForeignKey(nameof(StationId))]
 public Station Station { get; set; }
    
}