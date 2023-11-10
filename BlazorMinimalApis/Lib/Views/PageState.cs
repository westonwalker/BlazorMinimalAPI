using BlazorMinimalApis.Lib.Validation;

namespace BlazorMinimalApis.Lib.Views;

public class PageState
{
    public List<ValidationError> Errors { get; set; } = new();
}
