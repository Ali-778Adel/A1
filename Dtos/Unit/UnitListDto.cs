using System.Linq.Expressions;
using A1.Dtos.Station;
using LinqKit;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace A1.Dtos.Unit;

using System.Linq.Expressions;

public class UnitListDto
{
    public static Expression<Func<data.Entities.Unit, UnitListDto>> Mapper()
    {
        var stationExpression = StationGetDto.Mapper;
        return item => new UnitListDto()
        {
            Id = item.Id,
            Code = item.Code,
            Size = item.Size,
            Price = item.Price,
            NoteAr = item.NotesAr,
            NoteEn = item.NotesEn,
            UnitType = item.Type,
            UpdatedAt = item.UpdatedAt,
            CreatedAt = item.CreatedAt,
            StationGetDto = item.Station != null ? stationExpression.Compile().Invoke(item.Station) : null,
            Branch = item.Station != null ? item.Station.NameEn : null
        };
    }

    public Guid Id { get; set; }

    public int Code { get; set; }

    public string Size { get; set; }

    public string Price { get; set; }

    public List<string> NoteAr { get; set; }

    public List<string> NoteEn { get; set; }

    public string UnitType { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Branch { get; set; }
    public StationGetDto StationGetDto { get; set; }
}