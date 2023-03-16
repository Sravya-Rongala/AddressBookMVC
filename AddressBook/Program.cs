using AddressBook.Data;
using AddressBook.Interfaces;
using AddressBook.Repositories;
using AddressBook.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//EF

/*builder.Services.AddDbContext<ContactDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("default")
    ));
builder.Services.AddScoped<IContactServices, EFContactRepository>();
builder.Services.AddScoped<ContactServices>();*/

//DAPPER

builder.Services.AddScoped<ContactDetailsContext>();
builder.Services.AddScoped<IContactServices, DapperContactRepository>();
builder.Services.AddScoped<ContactServices>();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
