namespace BlazorMinimalApis.Lib.Validation;

public class ValidationResponse
{
    public bool HasErrors { get; set; } = true;
    public List<ValidationError> Errors { get; set; } = new();
}

public class ValidationError
{
    public string Message { get; set; }
    public string MemberName { get; set; }
}
