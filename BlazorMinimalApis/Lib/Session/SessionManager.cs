using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace BlazorMinimalApis.Lib.Session;

public class SessionManager
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetFlash(string key, string value)
    {
        if (_httpContextAccessor.HttpContext != null)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }
    }

    public void SetString(string key, string value)
    {
        if (_httpContextAccessor.HttpContext != null)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }
    }

    public string? GetString(string key)
    {
        if (_httpContextAccessor.HttpContext != null)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);
        }
        return "";
    }

    public string? GetFlash(string key)
    {
        if (_httpContextAccessor.HttpContext != null)
        {
            string? message = _httpContextAccessor.HttpContext.Session.GetString(key);
            _httpContextAccessor.HttpContext.Session.Remove(key);
            return message;
        }
        return "";
    }

    public bool HasKey(string key)
    {
        if (_httpContextAccessor.HttpContext != null)
        {
            string? message = _httpContextAccessor.HttpContext.Session.GetString(key);
            return string.IsNullOrEmpty(message) ? false : true;
        }
        return false;
    }
}
