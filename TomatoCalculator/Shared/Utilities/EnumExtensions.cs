using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace TomatoCalculator.Shared.Utilities
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var member = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            if (member == null || member.GetCustomAttribute<DisplayAttribute>() == null)
            {
                return enumValue.ToString();
            }
            else
            {
                return member.GetCustomAttribute<DisplayAttribute>().Name;

            }

        }
    }
}