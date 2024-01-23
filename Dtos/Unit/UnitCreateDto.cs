using System.ComponentModel.DataAnnotations;

namespace A1.Dtos.Unit;

public class UnitCreateDto
{
    public int Code { get; set; }

    public string Size { get; set; }

    public string  Price { get; set; }

    public List<string> NoteAr { get; set; }

    public List<string> NoteEn { get; set; }

    public Guid StationId { get; set; }

    public string UnitType { get; set; }
    public IFormFile Image { get; set; }
}