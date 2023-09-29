using BlazorMinimalApis.Components;
using BlazorMinimalApis.Components.Pages;
using BlazorMinimalApis.Lib;
using BlazorMinimalApis.Routes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAntiforgery();
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

app.MapPageRoutes();

// livewire
//app.MapPost("/update", ([FromBody] LivewirePayload payload, HttpContext context) =>
//{
//    var test = context;
//    var response = new LivewireResponse();

//    // users goes to /food/create
//        // livewire gets component and calls render(), returns html
//    // user submits /food/store
//        // livewire submits post request to /update with method and data
//        // livewire gets component, calls method, then render.

//    foreach (var component in payload.components)
//    {
//        response.components.Add(new ResponseComponent()
//        {
//            snapshot = component.snapshot
//        });
//    }
//    return response;
//}).DisableAntiforgery();

app.Run();