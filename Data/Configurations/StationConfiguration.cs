using A1.data.Entities;
using A1.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace A1.data.Configurations;

public class StationConfiguration : IEntityTypeConfiguration<Station>
{
    public void Configure(EntityTypeBuilder<Station> builder)
    {
        builder.Property(x => x.MoreServices).HasConversion(HelperFunctions.ListConverter());
        builder.Property(x => x.ConditionsAr).HasConversion(HelperFunctions.ListConverter());
        builder.Property(x => x.ConditionsEn).HasConversion(HelperFunctions.ListConverter());
        builder.Property(x => x.Image).HasConversion(
            v => Convert.ToBase64String(v),
            v => Convert.FromBase64String(v)
        );

        builder.Property(x => x.Layout).HasConversion(
            v => Convert.ToBase64String(v),
            v => Convert.FromBase64String(v)
        );
    }
}