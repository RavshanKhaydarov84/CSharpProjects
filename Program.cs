using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FloatingPointIssue
{
    class Program
    {
        static void funcReadNum()
        {
            double f1 = 0;
            string s1 = "";
            CultureInfo culture = CultureInfo.CurrentCulture;
            Console.WriteLine("Culture: {0}", culture);
            Console.WriteLine("Input floating point number:");
            s1 = Console.ReadLine();
            if (Double.TryParse(s1, NumberStyles.Float, culture, out f1))
            {
                Console.WriteLine("\nConverted '{0}' to {1} using Culture {2}", s1, f1, culture);
            }
            else
            {
                Console.WriteLine("\nConvert through {0} was not possible, using all cultures:", culture);
                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
                foreach(CultureInfo iCulture in cultures)
                {
                    if (Double.TryParse(s1, NumberStyles.AllowDecimalPoint, iCulture, out f1))
                    {
                        Console.WriteLine("\nSuccessfully converted '{0}' to {1} using Culture {2}", s1, f1, iCulture);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nError at parsing number {0} using Culture {1}!", s1, iCulture);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            do
            {
                funcReadNum();
                Console.WriteLine("\nWould you like to continue (No: ESC, Yes: Any other key) ?");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
