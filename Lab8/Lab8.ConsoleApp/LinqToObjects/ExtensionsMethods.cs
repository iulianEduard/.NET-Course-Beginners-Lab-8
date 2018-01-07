using System;
using System.Reflection;

namespace Lab8.ConsoleApp.LinqToObjects
{
    public static class ExtensionsMethods
    {
        public static void DisplayAssemblyInformation(this object obj)
        {
            Console.WriteLine($"{obj.GetType().Name} -> {Assembly.GetAssembly(obj.GetType())}");
        }

        public static string ToCustomDateTime(this DateTime date)
        {
            return $"{date.Day}/{date.Month}/{date.Year} {date.Hour}:{date.Minute}";
        }
    }
}
