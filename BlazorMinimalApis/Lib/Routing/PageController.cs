using BlazorMinimalApis.Lib.Views;
using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorMinimalApis.Lib.Routing;

public abstract class PageController
{
    public ValidationResponse Validation = new();

    public IResult Page<TComponent>(object data)
    {
        var componentData = data.ToDictionary();
        var errors = new List<ValidationError>();
        if (Validation.HasErrors && Validation.Errors.Count > 0)
        {
            errors = Validation.Errors;
        }
        var componentType = typeof(TComponent);
        return new RazorComponentResult(typeof(PageComponent), new { ComponentType = componentType, ComponentParameters = componentData, Errors = errors });
    }

    public IResult Page<TComponent>()
    {
        return Page<TComponent>(new { });
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

    public ValidationResponse Validate<TData, TValidator>(TData data, TValidator validator) where TValidator : AbstractValidator<TData>
    {
        ValidationResponse validationResponse = new();
        FluentValidation.Results.ValidationResult results = validator.Validate(data);

        if (!results.IsValid)
        {
            validationResponse.HasErrors = true;
            foreach (var error in results.Errors)
            {
                var ve = new ValidationError()
                {
                    Message = error.ErrorMessage,
                    MemberName = error.PropertyName
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

    public async Task<ValidationResponse> ValidateAsync<TData, TValidator>(TData data, TValidator validator) where TValidator : AbstractValidator<TData>
    {
        ValidationResponse validationResponse = new();
        FluentValidation.Results.ValidationResult results = await validator.ValidateAsync(data);

        if (!results.IsValid)
        {
            validationResponse.HasErrors = true;
            foreach (var error in results.Errors)
            {
                var ve = new ValidationError()
                {
                    Message = error.ErrorMessage,
                    MemberName = error.PropertyName
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

    public void AddError(string key, string message)
    {
        Validation.HasErrors = true;
        Validation.Errors.Add(new ValidationError() { MemberName = key, Message = message });
    }

    public IResult Redirect(string url)
    {
        return Results.Redirect(url);
    }

    public PageController Flash(string key, string message)
    {
        return this;
    }
}
