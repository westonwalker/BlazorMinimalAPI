using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMinimalApis.Endpoints.Api.Example;

public class ExampleHandler
{
    public static IResult Index()
    {
        var data = new { Hello = "World" };
        return Results.Ok(data);
    }
}