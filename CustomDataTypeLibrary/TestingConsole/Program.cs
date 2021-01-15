using CustomDataTypeLibrary;
using System;

namespace TestingConsole
{
   class Program
   {
      static void Main(string[] args)
      {
         //var meterA = new Metric(1, Measurement.Meter);
         //meterA.SetFullValue(2000);
         //var meterB = new Metric(1, Measurement.Meter);
         //meterB.SetValue(2, Prefix.Kilo);

         var negA = new Metric(-2000);
         negA.SetValue(-2, Prefix.Milli);

         Console.WriteLine("\nEnd..");
         Console.ReadLine();
      }
   }
}
