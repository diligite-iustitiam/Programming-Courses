using Course_Site.Controllers;
using Course_Site.Models;
using Course.Shared;
using Course_Site.Data;


using Microsoft.Extensions.DependencyInjection;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using Course_Site.Data;





var builder = WebApplication.CreateBuilder(args);

SchoolContext schoolContext = new();
DbInitializer.Initialize(schoolContext);

// Add services to the container.

var AcademyConnection = builder.Configuration.GetConnectionString("DefaultConnection");
var SqLiteconnection = builder.Configuration.GetConnectionString("NorthwindConnection");
var SchoolConnection = builder.Configuration.GetConnectionString("SchoolContextConnection");


builder.Services.AddNorthwindContext();
builder.Services.AddSchoolContext();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlite(SchoolConnection));

builder.Services.AddControllersWithViews();



    var app = builder.Build();

 


    // Configure the HTTP request pipeline.
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

