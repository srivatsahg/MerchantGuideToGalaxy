using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyGuide;



namespace GalaxyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            //CurrencyConvertor currencyConvertor = new CurrencyConvertor();
            //var inputExpression = "glob is I";
            //currencyConvertor.Evaluate(inputExpression);
            //Console.ReadKey();

            RomanValueCalculator romanValueCalculator = new RomanValueCalculator();
            Console.WriteLine(romanValueCalculator.Convert("MC"));
            Console.ReadKey();
        }
    }
}
