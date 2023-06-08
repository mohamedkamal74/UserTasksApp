﻿using System.Reflection;


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

    //public static List<DropDownList> GetVisitTypeList()
    //{
    //    return Enum.GetValues(typeof(PeriorityEnum))
    //       .Cast<PeriorityEnum>()
    //       .Select(t => new DropDownList
    //       {
    //           Id = ((int)t),
    //           Name = t.GetDisplayName()
    //       }).ToList();
    //}
}
