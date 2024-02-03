using A1.data.Entities;
using A1.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace A1.data.Configurations;

public class UnitConfiguration: IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.Property(x => x.NotesAr).HasConversion(HelperFunctions.ListConverter());
        builder.Property(x => x.NotesEn).HasConversion(HelperFunctions.ListConverter());

        builder.Property(x => x.Image).HasConversion(
            v => Convert.ToBase64String(v),
            v => Convert.FromBase64String(v)
        );
    }
}