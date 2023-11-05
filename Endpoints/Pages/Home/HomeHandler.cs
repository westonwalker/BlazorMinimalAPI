using BlazorMinimalApis.Data;
using BlazorMinimalApis.Lib;
using BlazorMinimalApis.Lib.Routing;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlazorMinimalApis.Endpoints.Pages.Home;

public class HomeHandler : PageHandler
{
    public IResult Index(IHttpContextAccessor _httpContext)
    {
        return Page<Home>();
    }

    public IResult RandomNumber()
    {
        Random rnd = new Random();
        var Num = rnd.Next();
        return Page<RandomNumber>(new { Num });
    }
}