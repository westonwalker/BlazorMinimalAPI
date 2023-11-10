using BlazorMinimalApis.Lib.Session;
using BlazorMinimalApis.Mvc.Lib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAntiforgery();
builder.Services.AddTransient<SessionManager>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options => {
	options.IdleTimeout = TimeSpan.FromMinutes(1);
});
//builder.Services.AddAuthentication<IAuthValidator>();
//builder.Services.AddAuthorization(new string[] { "Admin", "User" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseAntiforgery();

app.RegisterRoutes();

app.Run();