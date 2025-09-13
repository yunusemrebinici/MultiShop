using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
var app = builder.Build();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
	opt.LoginPath = "/Login/Index/";
	opt.LogoutPath = "/Login/LogOut/";
	opt.AccessDeniedPath = "/Pages/AccessDenied/";
	opt.Cookie.HttpOnly = true;
	opt.Cookie.SameSite = SameSiteMode.Strict;
	opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
	opt.Cookie.Name = "MultiShopJwt";
});

builder.Services.AddHttpContextAccessor();
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
	// Area'lar i�in y�nlendirme, default y�nlendirmeden �nce tan�mlanmal�d�r.
	endpoints.MapControllerRoute(
	 name: "areas",
	 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);

	// Genel (default) y�nlendirme
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
