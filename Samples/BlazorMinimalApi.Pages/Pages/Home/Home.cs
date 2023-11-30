using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;
using System;

namespace BlazorMinimalApis.Pages.Pages.Home;

public class Home : XPage 
{
    public int Num;

    public IResult Get()
    {
        return Page<_Home>();
    }

    public IResult RandomNumber()
    {
        Random rnd = new Random();
		Num = rnd.Next();
        return Page<_RandomNumber>();
    }
}