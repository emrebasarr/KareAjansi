using KareAjansi.BLL.Repositories;
using KareAjansi.BLL.Services;
using KareAjansi.DAL.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //api dahil ediyoruz.

//DbContext
builder.Services.AddDbContext<KareAjansiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Dependency Injection (Baðýmlýlýðý dahil etmek)
builder.Services.AddScoped<IMankenRepository,MankenService>();
builder.Services.AddScoped<IOrganizasyonRepository, OrganizasyonService>();
builder.Services.AddScoped<IOrganizasyonMankenRepository, OrganizasyonMankenService>();
builder.Services.AddScoped<IYorumRepository,YorumService>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", cors =>
    {
        cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

//Application
var app = builder.Build(); //application derleniyor.

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("CORS");

app.MapControllers();

app.Run();