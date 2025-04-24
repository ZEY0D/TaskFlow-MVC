using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Data.Service;
using ToDo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connect to SQLite (Make sure you have the right connection string in `appsettings.json`)
var connectionString = builder.Configuration.GetConnectionString("ToDoConnection");
builder.Services.AddDbContext<ToDoContext>(options => 
    options.UseSqlite(connectionString));

// Register services (task-related services)
builder.Services.AddScoped<ITaskService, TaskService>();

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ToDoContext>()
    .AddDefaultTokenProviders();

// Add authentication and authorization middleware
builder.Services.AddAuthentication()
    .AddCookie();

var app = builder.Build();

// Configure the middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Add this to ensure authentication middleware is used
app.UseAuthorization();  // Add this to ensure authorization middleware is used

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
