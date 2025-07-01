using Microsoft.EntityFrameworkCore;
using GimnasioApp.Infrastructure.Data;
using GimnasioApp.Core.Interfaces;
using GimnasioApp.Infrastructure.Repositories;
using GimnasioApp.Application.Services;
using GimnasioApp.Application.Mappings;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GimnasioDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ISocioRepository, SocioRepository>();
builder.Services.AddScoped<IClaseRepository, ClaseRepository>();

builder.Services.AddScoped<ISocioService, SocioService>();
builder.Services.AddScoped<IClaseService, ClaseService>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();