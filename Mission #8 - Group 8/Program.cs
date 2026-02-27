using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Mission__8___Group_8.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration["ConnectionStrings:TaskConnection"]);
    });

builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Categories.Any())
    {
        context.Categories.AddRange(
            new Category { CategoryName = "Home" },
            new Category { CategoryName = "School" },
            new Category { CategoryName = "Work" },
            new Category { CategoryName = "Church" }
        );
        context.SaveChanges();
    }

    if (!context.Quadrants.Any())
    {
        context.Quadrants.AddRange(
            new Quadrant { QuadrantName = "Important / Urgent" },
            new Quadrant { QuadrantName = "Important / Not Urgent" },
            new Quadrant { QuadrantName = "Not Important / Urgent" },
            new Quadrant { QuadrantName = "Not Important / Not Urgent" }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
