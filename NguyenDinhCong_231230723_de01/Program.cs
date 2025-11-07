using Microsoft.EntityFrameworkCore;
using ndc_231230723_de01.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var ndcConnection = builder.Configuration.GetConnectionString("NdcComputerConnection");
builder.Services
    .AddDbContext<NdcComputerContext>(options => options
                                                        .UseSqlServer(ndcConnection));


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
    pattern: "{controller=NdcHome}/{action=NdcIndex}/{id?}");

app.Run();
