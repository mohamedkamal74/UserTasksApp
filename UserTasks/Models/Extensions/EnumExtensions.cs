using System.Reflection;


namespace UserTasks.Models.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumType)
    {
        return enumType.GetType().GetMember(enumType.ToString())
                       .First()
                       .GetCustomAttribute<DisplayAttribute>()
                       .Name;
    }
}
