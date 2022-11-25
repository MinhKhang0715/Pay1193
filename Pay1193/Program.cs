using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Pay1193.Persistence;
using Pay1193.Services;
using Pay1193.Services.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
{
    //opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    var connectionString = "DataSource=myshareddb;mode=memory;cache=shared";
    var sqliteConnection = new SqliteConnection(connectionString);
    sqliteConnection.Open();
    opts.UseSqlite(sqliteConnection);
});

builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<IPayService, PayService>();
var app = builder.Build();

using (var appScope = app.Services.CreateScope())
{
    var dcContext = appScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dcContext.Database.EnsureDeleted();
    dcContext.Database.EnsureCreated();
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
