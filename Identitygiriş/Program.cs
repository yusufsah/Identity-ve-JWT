using dataacseslayer.contraet;
using Entity.cont;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TravelReservation.Models;

var builder = WebApplication.CreateBuilder(args);








builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddDbContext<context>();
builder.Services.AddIdentity<appuser, AppRole>().AddEntityFrameworkStores<context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<context>();
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
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
