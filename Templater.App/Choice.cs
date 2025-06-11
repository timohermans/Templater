using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Templater.App;

public class Choice<T> where T : Enum
{
    public string Display { get; }
    public T Value { get; }

    public Choice(T e)
    {
        var memberInfo = typeof(MainActions).GetMember(e.ToString()).FirstOrDefault();
        var displayAttribute = memberInfo?.GetCustomAttribute<DisplayAttribute>();
        var display = displayAttribute == null ? e.ToString() : displayAttribute.Name ?? throw new InvalidOperationException("Enum should never be null"); 
        
        Display = display;
        Value = e;
    }
}