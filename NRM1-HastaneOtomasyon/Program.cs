using Hastane.DataAccess.Abstract;
using Hastane.DataAccess.EntityFramework.Concrete;
using Hastane.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using NRM1_HastaneOtomasyon.Models.SeedDataFolder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSession(options => {
//    options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
//});
builder.Services.AddDbContext<HastaneDbContext>(_ =>
{
    _.UseSqlServer(builder.Configuration.GetConnectionString("HastaneConnString"));
});

builder.Services.AddScoped<IAdminRepo, AdminRepo>(); //iadminrepo ver dedigim zaman admin repo ver
builder.Services.AddScoped<IManagerRepo, ManagerRepo>();
builder.Services.AddScoped<IPersonnelRepo, PersonnelRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

SeedData.Seed(app); //program ayaga kalkacak asag� dogru kodlar cal�sacak  seeddata gelince seed  metodunu cal�st�racak admin veritaban�ma veri gitmis olacak

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
