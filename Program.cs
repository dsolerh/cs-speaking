#nullable enable
using System;
using System.Linq;
using System.Reflection;

using static System.Console;

namespace speaking_cs
{
    class Address
    {
        public string? Building;
        public string Street = string.Empty;
        public string City = string.Empty;
        public string Region = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Clear();
            Beep();
            WriteLine("\nTypes in c#\n");
            var assembly = Assembly.GetEntryAssembly()?.GetReferencedAssemblies();
            if (assembly != null)
            {
                foreach (var r in assembly)
                {
                    var a = Assembly.Load(new AssemblyName(r.FullName));
                    int count = 0;

                    foreach (var t in a.DefinedTypes)
                    {
                        count += t.GetMethods().Count();
                    }

                    WriteLine(
                        "{0:N0} types with {1:N0} methods in {2} assembly.",
                        arg0: a.DefinedTypes.Count(),
                        arg1: count,
                        arg2: r.Name
                    );
                }
            }

            WriteLine("\nVariables in c#\n");
            double heightInMetres = 1.88;
            WriteLine(
                $"The variable {nameof(heightInMetres)} has the value { heightInMetres}."
            );
            string filePath = @"C:\televisions\sony\bravia.txt";
            WriteLine($"File path: {filePath}");

            WriteLine("\nNumbers in c#\n");
            uint naturalNumber = 2_202_543;
            uint naturalNumberBynary = 0b_1110_1010_1001;
            uint naturalNumberHex = 0x001E_8480;
            int integerNumber = -1;
            float realNumber = 2.3F;
            double otherRealNumber = 2.3;
            WriteLine($"Natural Number: {naturalNumber}");
            WriteLine($"Natural Number (binary): {naturalNumberBynary}");
            WriteLine($"Natural Number (hex): {naturalNumberHex}");
            WriteLine($"Integer Number: {integerNumber}");
            WriteLine($"Real Number (single): {realNumber}");
            WriteLine($"Real Number (double): {otherRealNumber}");

            WriteLine(
                "int uses {0} bytes and can storenumbers in the range {1:N0} to {2:N0}.",
                arg0: sizeof(int),
                arg1: int.MinValue,
                arg2: int.MaxValue
            );
            WriteLine(
                "double uses {0} bytes and canstore numbers in the range {1} to {2}.",
                arg0: sizeof(double),
                arg1: double.MinValue,
                arg2: double.MaxValue
            );
            WriteLine(
                "decimal uses {0} bytes and canstore numbers in the range {1:N0} to {2:N0}.",
                arg0: sizeof(decimal),
                arg1: decimal.MinValue,
                arg2: decimal.MaxValue
            );

            WriteLine("\nUsing c# doubles:\n");
            double x = 0.1;
            double y = 0.2;
            if (x + y == 0.3)
            {
                WriteLine($"{x} + {y} == 0.3");
            }
            else
            {
                WriteLine($"{x} + {y} != 0.3");
            }

            WriteLine("\nUsing c# decimals:\n");
            decimal c = 0.1M; // M suffix means a decimal literal value
            decimal d = 0.2M;
            if (c + d == 0.3M)
            {
                WriteLine($"{c} + {d} == 0.3");
            }
            else
            {
                WriteLine($"{c} + {d} != 0.3");
            }

            WriteLine("\nStoring in an Object:\n");
            object height = 1.88; // storing a double in an object
            object name = "Amir"; // storing a string in an object
            WriteLine($"{name} is {height} metres tall.");
            // int length1 = name.Length; // gives compile error!
            int length2 = ((string)name).Length; // tell compiler it is a string
            WriteLine($"{name} has {length2} characters.");

            WriteLine("\nDefault values:\n");
            WriteLine($"default(int) = {default(int)}");
            WriteLine($"default(float) = {default(float)}");
            WriteLine($"default(double) = {default(double)}");
            WriteLine($"default(decimal) = {default(decimal)}");
            WriteLine($"default(bool) = {default(bool)}");
            WriteLine($"default(string) = {default(string)}");
            WriteLine($"default(DateTime) = {default(DateTime)}");

            WriteLine("\nArrays:\n");
            string[] names = new string[4];

            names[0] = "Kate";
            names[1] = "Jack";
            names[2] = "Rebecca";
            names[3] = "Tom";

            for (int i = 0; i < names.Length; i++)
            {
                // output the item at index position i
                WriteLine(names[i]);
            }

            WriteLine("\nNullable:\n");
            int thisCannotBeNull = 4;
            WriteLine($"{nameof(thisCannotBeNull)} = null; -> compile error!");
            int? thisCouldBeNull = null;
            WriteLine($"{nameof(thisCouldBeNull)} = {thisCouldBeNull}");
            WriteLine($"thisCouldBeNull.GetValueOrDefault() = {thisCouldBeNull.GetValueOrDefault()}");
            thisCouldBeNull = 7;
            WriteLine($"{nameof(thisCouldBeNull)} = {thisCouldBeNull}");
            WriteLine($"thisCouldBeNull.GetValueOrDefault() = {thisCouldBeNull.GetValueOrDefault()}");

            var address = new Address();
            address.Building = null;
            address.Street = "null";
            address.City = "London";
            address.Region = "null";

            // result will be 3 if authorName?.Length is null
            string? authorName = null;
            var result = authorName?.Length ?? 3;
            WriteLine(result);

            WriteLine("\nString Formatting:\n");

            int numberOfApples = 12;
            decimal pricePerApple = 0.35M;
            WriteLine(
                format: "{0} apples costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples
            );

            string formatted = string.Format(
                format: "{0} apples costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples
            );
            //WriteToFile(formatted); // writes the string into a file
            WriteLine($"{numberOfApples} apples costs {pricePerApple * numberOfApples:C}");

            string applesText = "Apples";
            int applesCount = 1234;
            string bananasText = "Bananas";
            int bananasCount = 56789;

            WriteLine(
                format: "{0,-8} {1,6:N0}",
                arg0: "Name",
                arg1: "Count"
            );
            WriteLine(
                format: "{0,-8} {1,6:N0}",
                arg0: applesText,
                arg1: applesCount
            );
            WriteLine(
                format: "{0,-8} {1,6:N0}",
                arg0: bananasText,
                arg1: bananasCount
            );

            // WriteLine("\nUser Input:\n");
            // Write("Type your first name and press ENTER: ");
            // string? firstName = ReadLine() ?? "Daniel";

            // Write("Type your age and press ENTER: ");
            // string? age = ReadLine() ?? "24";

            // WriteLine($"Hello {firstName}, you look good for {age}.");

            // Write("Press any key combination: ");
            // ConsoleKeyInfo key = ReadKey();
            // WriteLine();
            // WriteLine(
            //     "Key: {0}, Char: {1}, Modifiers: {2}",
            //     arg0: key.Key,
            //     arg1: key.KeyChar,
            //     arg2: key.Modifiers
            // );

            WriteLine("\nGetting arguments:\n");
            WriteLine($"There are {args.Length} arguments.");
            if (args.Length < 4)
            {
                WriteLine("You must specify two colors and dimensions, e.g.");
                WriteLine("dotnet run red yellow 80 40");
                return; // stop running
            }
            ForegroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[0],
                ignoreCase: true
            );
            BackgroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[1],
                ignoreCase: true
            );
            try
            {
                WindowWidth = int.Parse(args[2]);
                WindowHeight = int.Parse(args[3]);
            }
            catch (PlatformNotSupportedException)
            {
                WriteLine("The current platform does not support changing the size of a console window.");
            }
            foreach (var arg in args)
            {
                WriteLine(arg);
            }
        }
    }
}
