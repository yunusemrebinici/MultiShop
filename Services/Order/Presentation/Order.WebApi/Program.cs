using Application.Features.CQRS.Handlers.AddressHandlers;
using Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Persistance.Context;
using Persistance.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
	x.Authority = builder.Configuration["IdentityServerUrl"];
	x.Audience = "ResourceOrder";
	x.RequireHttpsMetadata = false;

});


// Add services to the container
builder.Services.AddDbContext<OrderContext>();
builder.Services.AddScoped(typeof(IOrderDetailService), typeof(OrderDetailService));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<GetOrderDetailByOrderingIdQueryHandler>();
builder.Services.AddApplicationService(builder.Configuration);

#region 
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<GetAddressQueryHandle>();
builder.Services.AddScoped<RemoveAddressCommandHandle>();
builder.Services.AddScoped<UpdateAddressCommandHandle>();

builder.Services.AddScoped<CreateOrderDetailCommandHandle>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandle>();
builder.Services.AddScoped<GetOrderDetailQueryHandle>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandle>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandle>();
#endregion


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
