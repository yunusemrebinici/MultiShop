using Cargo.BusinessLayer.Abstract;
using Cargo.BusinessLayer.Concrete;
using Cargo.DataAccessLayer.Abstract;
using Cargo.DataAccessLayer.Concrete;
using Cargo.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CargoContext>();

builder.Services.AddScoped<ICargoCompanyDal,EfCargoComanyDal>();
builder.Services.AddScoped<ICargoCustomerDal,EfCargoCustomerDal>();
builder.Services.AddScoped<ICargoDetailDal,EfCargoDetailDal>();
builder.Services.AddScoped<ICargoOperationDal,EfCargoOperationDal>();

builder.Services.AddScoped<ICargoCompanyService,CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerService,CargoCustomerManager>();
builder.Services.AddScoped<ICargoDetailService,CargoDetailManager>();
builder.Services.AddScoped<ICargoOperationService,CargoOperationManager>();


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
