using Microsoft.EntityFrameworkCore;
using TH_sql.Models;

var builder = WebApplication.CreateBuilder(args);

// ?? ??ng ký DbContext vào DI container
builder.Services.AddDbContext<ThWeb1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TH_Web_1")));

// ?? ??ng ký MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ?? C?u hình middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ?? ??nh ngh?a route m?c ??nh
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
