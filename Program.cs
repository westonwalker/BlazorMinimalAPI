using BlazorMinimalApis.Endpoints;
using BlazorMinimalApis.Lib;
using BlazorMinimalApis.Lib.Session;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Auth0.AspNetCore.Authentication;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


/*
// GET SECRETS FROM AZURE KEY VAULT

// Store VaultUri in appsettings.json or Launchsettings as env variable
var vaultUri = builder.Configuration["VaultUri"] ?? throw new ArgumentNullException("VaultUri");

// If you're developing locally, run az login to authenticate with Azure CLI.

Azure.Core.TokenCredential auth = new DefaultAzureCredential();
if (env == "Development")
{
    auth = new AzureCliCredential();
}


builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false) //load base settings
    .AddJsonFile($"appsettings.{env}.json", optional: false) //load environment settings
    .AddEnvironmentVariables()
    .AddAzureKeyVault(new Uri(vaultUri), auth);

*/

var auth0Domain = builder.Configuration["Auth0:Domain"] ?? throw new ArgumentNullException("Auth0:Domain");
var auth0ClientId = builder.Configuration["Auth0:ClientId"] ?? throw new ArgumentNullException("Auth0:ClientId");
var auth0ClientSecret = builder.Configuration["Auth0:ClientSecret"] ?? throw new ArgumentNullException("Auth0:ClientSecret");

services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = auth0Domain;
    options.ClientId = auth0ClientId;
    options.ClientSecret = auth0ClientSecret;
});

services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});


// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAntiforgery();
builder.Services.AddTransient<SessionManager>();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
});

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
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.UseSession();

app.MapPageEndpoints();
app.MapApiEndpoints();

app.Run();