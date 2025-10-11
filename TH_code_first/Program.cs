using TH_code_first.Data;
using TH_code_first.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var db = new SchoolContext())
{
    // CREATE
    var s = new Student { FullName = "Nguyen Van A", Age = 20 };
    db.Students.Add(s);
    db.SaveChanges();

    // READ
    var students = db.Students.ToList();
    foreach (var st in students)
        Console.WriteLine($"{st.Id} - {st.FullName} - {st.Age}");
}

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
