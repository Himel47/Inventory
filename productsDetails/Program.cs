using Inventory.AggregateRoot;
using Inventory.DTO.Models;
using Inventory.Handler.IServices;
using Inventory.Handler.Services;
using Inventory.Mapper;
using Inventory.Repository.DataContext;
using Inventory.Repository.IRepository;
using Inventory.Repository.IServices;
using Inventory.Repository.Repository;
using Inventory.Repository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Mapping
builder.Services.AddAutoMapper(typeof(MyMap).Assembly);

//Db Connection
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("myString")
));

//Interface mapping
builder.Services.AddScoped<IProductsHandler, ProductHandler>();
builder.Services.AddScoped<IStockHandler, StockHandler>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOperations, Operations>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));


//builder.Services.AddTransient<IGenericRepository<Product>, GenericRepository<Product>>();
//builder.Services.AddTransient<IGenericRepository<Stock>, GenericRepository<Stock>>();
//builder.Services.AddTransient<IGenericRepository<StockWithProduct>, GenericRepository<StockWithProduct>>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
