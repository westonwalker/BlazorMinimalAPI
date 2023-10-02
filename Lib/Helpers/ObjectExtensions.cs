using System.ComponentModel;

namespace BlazorMinimalApis.Lib.Helpers;

public static class ObjectExtensions
{
    public static Dictionary<string, object?> ToDictionary(this object values)
    {
        var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        if (values != null)
        {
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(values))
            {
                object obj = propertyDescriptor.GetValue(values);
                dict.Add(propertyDescriptor.Name, obj);
            }
        }

        return dict;
    }
}
