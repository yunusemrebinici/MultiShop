using Microsoft.AspNetCore.Authentication.JwtBearer;
using MShop.WebUI.Services;
using Microsoft.AspNetCore.Authentication.Cookies; // Cookie Authentication için gerekli namespace

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

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddHttpContextAccessor();

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