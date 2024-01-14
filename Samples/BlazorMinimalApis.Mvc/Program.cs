using BlazorMinimalApis.Lib.Session;
using BlazorMinimalApis.Mvc.Data;
using BlazorMinimalApis.Mvc.Lib;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RambosaDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("RambosaDbContext"))
);
builder.Services.AddRazorComponents();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAntiforgery();
builder.Services.AddTransient<SessionManager>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options => {	
	options.Cookie.Name = ".blazorminimalapi.mvc";
	options.IdleTimeout = TimeSpan.FromMinutes(1);
});
//builder.Services.AddAuthentication<IAuthValidator>();
//builder.Services.AddAuthorization(new string[] { "Admin", "User" });

var app = builder.Build();

//Para crear la base de datos en caso de que no exista
//Las db creadas de esta manera no pueden usar migraciones
//Ver mas: https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-8.0&tabs=visual-studio#create-the-web-app-project
/*using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var context = services.GetRequiredService<RambosaDbContext>();
	context.Database.EnsureCreated();
	// DbInitializer.Initialize(context);
}*/

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