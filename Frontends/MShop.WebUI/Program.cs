using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using MShop.WebUI.Services.Interfaces;
using MShop.WebUI.Services.Concrete;
using MShop.WebUI.Settings;
using MShop.WebUI.Handlers;
using MShop.WebUI.Services.CatalogServices.CategoryServices;
using MShop.WebUI.Services.CatalogServices.ProductServices;
using MShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using MShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MShop.WebUI.Services.CatalogServices.FeatureServices;
using MShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using MShop.WebUI.Services.CatalogServices.BrandServices;
using MShop.WebUI.Services.CatalogServices.FeatureProductServices;
using MShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MShop.WebUI.Services.CatalogServices.ProductImageServices;
using MShop.WebUI.Services.CommentServices;
using MShop.WebUI.Services.CatalogServices.ContactServices;
using MShop.WebUI.Services.BasketServices;
using MShop.WebUI.Services.DiscountServices;
using MShop.WebUI.Services.OrderServices.Ordering;
using MShop.WebUI.Services.OrderServices.Address;
using MShop.WebUI.Services.OrderServices.AddressService;
using MShop.WebUI.Services.OrderServices.OrderDetail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Kimlik doðrulama servislerini buraya ekleyin, builder.Build()'dan önce
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
	{
		opt.LoginPath = "/Login/Index/";
		opt.LogoutPath = "/Login/LogOut/";
		opt.AccessDeniedPath = "/Pages/AccessDenied/";
		opt.Cookie.HttpOnly = true;
		opt.Cookie.SameSite = SameSiteMode.Strict;
		opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
		opt.Cookie.Name = "MultiShopJwt";
	});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
	AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
	opt.LoginPath = "/Login/Index/";
	opt.ExpireTimeSpan = TimeSpan.FromDays(5);
	opt.Cookie.Name = "MultiShopCookie";
	opt.SlidingExpiration = true;

});

builder.Services.AddMemoryCache();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IIdentityService,IdentityService>();

builder.Services.AddScoped<ResourcheOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));
var values=builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();


builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
	opt.BaseAddress = new Uri(values.IdentityServerUrl);

}).AddHttpMessageHandler<ResourcheOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
	opt.BaseAddress=new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductService, ProductService>(opts =>
{
	opts.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opts =>
{
	opts.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureService, FeatureService>(opts =>
{
	opts.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();	

builder.Services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");

}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IBrandService, BrandService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureProductService, FeatureProductService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductImageService, ProcuctImageService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Comment.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Basket.Path}");
}).AddHttpMessageHandler<ResourcheOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IDiscountService, DiscountService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Discount.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IOrderingService, OrderingService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourcheOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IAddressService, AddressService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourcheOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IOrderDetailService, OrderDetailService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotServerUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourcheOwnerPasswordTokenHandler>();

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	 name: "areas",
	 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();