using System.Globalization;

namespace A1.Constants;

public static class SupportedCultures
{
    public const string LanguageArabic = "ar";
    public const string LanguageEnglish = "en";

    public const string CountryUae = "EG";

    public static readonly CultureInfo Arabic = new CultureInfo($"{LanguageArabic}-{CountryUae}");
    public static readonly CultureInfo English = new CultureInfo($"{LanguageEnglish}-{CountryUae}");

    public static CultureInfo[] All =
    {
        Arabic,
        English
    };

    public static CultureInfo Default = Arabic;
};