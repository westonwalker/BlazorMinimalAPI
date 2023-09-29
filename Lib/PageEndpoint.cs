using BlazorMinimalApis.Lib.Helpers;
using Microsoft.AspNetCore.Components.Endpoints;
using System.ComponentModel.DataAnnotations;

namespace BlazorMinimalApis.Lib;

public abstract class PageEndpoint
{
    public ValidationResponse Validation = new();

    public virtual IResult Component<TComponent>(object data)
    {
        var componentData = data.ToDictionary();
        if (Validation.HasErrors && Validation.Errors.Count > 0)
        {
            componentData.Add("Errors", Validation.Errors);
        }
        return new RazorComponentResult(typeof(TComponent), componentData);
    }

    public virtual IResult Component<TComponent>()
    {
        var componentData = new Dictionary<string, object?>();
        if (Validation.HasErrors && Validation.Errors.Count > 0)
        {
            componentData.Add("Errors", Validation.Errors);
        }
        return new RazorComponentResult(typeof(TComponent), componentData);
    }

	public ValidationResponse Validate<TData>(TData data)
    {
        var ctx = new ValidationContext(data);
        var results = new List<ValidationResult>();
        ValidationResponse validationResponse = new();
        if (!Validator.TryValidateObject(data, ctx, results, true))
        {
            validationResponse.HasErrors = true;
            foreach (var error in results)
            {
                Console.WriteLine("Error {0}", error);
                var ve = new ValidationError()
                {
                    Message = error.ErrorMessage,
                    MemberName = error.MemberNames.First(),
                };
                validationResponse.Errors.Add(ve);
            }
        }
        else
        {
            validationResponse.HasErrors = false;
        }
        Validation = validationResponse;
        return validationResponse;
    }

    public ValidationResponse GetErrors()
    {
        return Validation;
    }

    public ValidationResponse F<TData>(TData data)
	{
		var ctx = new ValidationContext(data);
		var results = new List<ValidationResult>();
		ValidationResponse validationResponse = new();
		if (!Validator.TryValidateObject(data, ctx, results, true))
		{
			validationResponse.HasErrors = false;
			foreach (var error in results)
			{
				Console.WriteLine("Error {0}", error);
				var ve = new ValidationError()
				{
					Message = error.ErrorMessage,
					MemberName = error.MemberNames.First(),
				};
				validationResponse.Errors.Add(ve);
			}
		}
		else
		{
			validationResponse.HasErrors = true;
		}
		return validationResponse;
	}

	public void Map<TData>(TData data)
    {
    }

    public IResult Redirect(string url)
    {
        return Results.Redirect(url);
    }
}
