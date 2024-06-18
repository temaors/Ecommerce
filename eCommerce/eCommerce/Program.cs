using eCommerce;
using eCommerce.Database;
using eCommerce.Database.DbEntities;
using eCommerce.Database.Repositories;
using eCommerce.Database.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

builder.ConfigureServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseCors(b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseStaticFiles();
app.UseAuthorization();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();