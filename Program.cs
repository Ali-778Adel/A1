using A1.Constants;
using A1.CultureProviders;
using A1.data;
using A1.Resources.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//configure localization
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture =
        new RequestCulture(culture: SupportedCultures.Default, SupportedCultures.Default);
    options.SupportedCultures = SupportedCultures.All;
    options.SupportedUICultures = SupportedCultures.All;

    options.RequestCultureProviders = new List<IRequestCultureProvider>(
        new[] { new HeaderRequestCultureProvider() }
    );
});

// Add Data annotation localization.
builder.Services.AddMvc()
    //.AddNewtonsoftJson()
    .AddDataAnnotationsLocalization(options =>
        options.DataAnnotationLocalizerProvider = (_, f) => f.Create(typeof(ModelsResource)));


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

// Localize strings.
app.UseRequestLocalization();

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
dbContext.Database.Migrate();

app.Run();