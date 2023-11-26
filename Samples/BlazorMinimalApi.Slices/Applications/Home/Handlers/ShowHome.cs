using BlazorMinimalApis.Slices.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Slices.Lib;
using Microsoft.AspNetCore.Mvc;
using BlazorMinimalApis.Slices.Applications.Home.Views;

namespace BlazorMinimalApis.Slices.Applications.Home.Handlers;

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