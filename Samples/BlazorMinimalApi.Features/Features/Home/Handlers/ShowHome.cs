using BlazorMinimalApis.Features.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Features.Lib;
using Microsoft.AspNetCore.Mvc;
using BlazorMinimalApis.Features.Features.Home.Views;

namespace BlazorMinimalApis.Features.Features.Home.Handlers;

public class ShowHome : XHandler
{
	public IResult Show()
	{
		return View<Show>();
	}

	public IResult RandomNumber()
	{
		Random rnd = new Random();
		var num = rnd.Next();
		return View<_RandomNumber>(new { Num = num });
	}
}