using M.Shop.Catalog.Services.CategoryServices;
using MongoDB.Bson.Serialization;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using M.Shop.Catalog.Services.ProductServices;
using M.Shop.Catalog.Services.ProductDetailServices;
using M.Shop.Catalog.Services.ProductImageServices;
using System.Reflection;
using M.Shop.Catalog.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDatabaseSettings,DatabaseSettings>();
builder.Services.AddScoped<ICategoryService,CategoryServices>();
builder.Services.AddScoped<IProductServices,ProductServices>();
builder.Services.AddScoped<IProductDetailServices,ProductDetailServices>();
builder.Services.AddScoped<IProductImageServices,ProductImageServices>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService <IOptions<DatabaseSettings>>().Value;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
