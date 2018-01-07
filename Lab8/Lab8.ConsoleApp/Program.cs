using Lab8.ConsoleApp.LinqToObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region Extensions Methods

        static void ExtensionMethodsExample1()
        {
            int x = 5;
            double y = 8.9;
            string s = "This is your name";

            x.DisplayAssemblyInformation();
            y.DisplayAssemblyInformation();
            s.DisplayAssemblyInformation();

            Console.ReadKey();
        }

        static void ExtensionMethodsExample2()
        {
            var currentDate = DateTime.Now;
            Console.WriteLine(currentDate.ToCustomDateTime());

            var futureDate = DateTime.Now.AddYears(10);
            Console.WriteLine(futureDate.ToCustomDateTime());

            Console.ReadKey();
        }

        static void ExtensionMethodsExample3()
        {
            var cusomObject = new {
                CurrentDate = DateTime.Now,
                Item = new { Name = "Asus", Description = "NX-550" },
                Price = 3500
            };

            cusomObject.DisplayAssemblyInformation();
        }

        #endregion Extensions Methods
    }
}
