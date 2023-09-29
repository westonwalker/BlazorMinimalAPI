using BlazorMinimalApis.Data;
using BlazorMinimalApis.Lib;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlazorMinimalApis.Components.Pages.Contacts;

public class HomeHandler : PageEndpoint
{
    public IResult Render()
	{
		return Component<Home>();
    }

    public IResult RandomNumber()
	{
		Random rnd = new Random();
		var Num = rnd.Next();
		return Component<RandomNumber>( new { Num } );
    }
}