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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using M.Shop.Catalog.Services.FeatureSliderServices;
using M.Shop.Catalog.Services.SpecialOfferServices;
using M.Shop.Catalog.Services.FeatureServices;
using M.Shop.Catalog.Services.FeatureProductServices;
using M.Shop.Catalog.Services.OfferDiscountServices;
using M.Shop.Catalog.Services.BrandServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata= false;

});

// Add services to the container.
builder.Services.AddScoped<IDatabaseSettings,DatabaseSettings>();
builder.Services.AddScoped<ICategoryService,CategoryServices>();
builder.Services.AddScoped<IProductServices,ProductServices>();
builder.Services.AddScoped<IProductDetailServices,ProductDetailServices>();
builder.Services.AddScoped<IProductImageServices,ProductImageServices>();
builder.Services.AddScoped<IFeatureSliderService,FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferServices,SpecialOfferServices>();
builder.Services.AddScoped<IFeatureServices,FeatureServices>();
builder.Services.AddScoped<IFeatureProductServices,FeatureProductServices>();
builder.Services.AddScoped<IOfferDiscountServices,OfferDiscountServices>();
builder.Services.AddScoped<IBrandServices,BrandServices>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
