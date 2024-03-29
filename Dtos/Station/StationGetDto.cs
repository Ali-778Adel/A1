﻿using System.Linq.Expressions;

namespace A1.Dtos.Station;

public class StationGetDto
{
    public static Expression<Func<data.Entities.Station, StationGetDto>> Mapper => item => new StationGetDto()
    {
        Id = item.Id,
        Active = item.Active,
        NameAr = item.NameAr,
        NameEn = item.NameEn,
        Slug = item.Slug,
        Comapny = item.Company,
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
        UpdatedAt = item.UpdatedAt
    };

    public Guid Id { get; set; }

    public bool Active { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string Slug { get; set; }
    public data.Entities.Company Comapny { get; set; }
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
}