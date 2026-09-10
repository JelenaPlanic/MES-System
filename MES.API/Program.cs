using MES.Application.Interfaces;
using MES.Application.Mappings;
using MES.Application.Services;
using MES.Infrastructure.Persistence;
using MES.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

const string schemeId = "Bearer";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "MES API",
    Version = "v1",
    Description = "Informacioni sistem za podrsku izvrsavanju proizvodnje"
});

    // Definicija JWT autentifikacije u Swagger UI
    options.AddSecurityDefinition(schemeId, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Unesi JWT token u formatu: Bearer {token}"
    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference(schemeId, document)] = new List<string>()
    });
});


// registracija
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// servisi
builder.Services.AddScoped<IProductServise, ProductService>();
builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IDowntimeReasonService, DowntimeReasonService>();
builder.Services.AddScoped<IDefectTypeService, DefectTypeService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();

// autoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); // middleware za authorizaciju
app.MapControllers();

app.Run();