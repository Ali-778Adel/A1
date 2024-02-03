using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace A1.Helpers;

public static class HelperFunctions
{
    public static ValueConverter<List<string>, string> ListConverter()
    {
        return new ValueConverter<List<string>, string>(
            v => string.Join(',', v),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
        );
    }
}