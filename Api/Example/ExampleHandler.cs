namespace BlazorMinimalApis.Api.Example;

public class ExampleHandler
{
    public static IResult Index()
    {
        var data = new { Hello = "World" };
        return Results.Ok(data);
    }
}