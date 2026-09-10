using Microsoft.EntityFrameworkCore;
using MES.Infrastructure.Persistence;
using MES.Application.Interfaces;
using MES.Infrastructure.Persistence.Repositories;
using MES.Application.Services;
using MES.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// registracija
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// servisi
builder.Services.AddScoped<IProductServise, ProductService>();

// autoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization(); // middleware za authorizaciju
app.MapControllers();

app.Run();