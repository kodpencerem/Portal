using System;
using System.Reflection;

namespace VedasPortal.Components.VedasToastComponent.Extensions
{
    internal static class AssemblyExtensions
    {
        public static string InformationalVersion(this Type type)
        {
            return type.Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}
