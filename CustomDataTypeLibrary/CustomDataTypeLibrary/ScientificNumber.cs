using System;

namespace CustomDataTypeLibrary
{
   public struct ScientificNumber
   {
      public double BaseNumber { get; set; }
      public int Exponent { get; set; }

      public ScientificNumber(double baseNumber, int exponent)
      {
         BaseNumber = baseNumber;
         Exponent = exponent;
      }

      public dynamic Convert()
      {
         return BaseNumber * Math.Pow(10, Exponent);
      }

      public override string ToString()
      {
         return $"{BaseNumber} * {Exponent}^10";
      }

      public static double ToNumber(double baseNum, int exponent)
      {
         return baseNum * Math.Pow(10, exponent);
      }

      public double Value
      {
         get
         {
            return Convert();
         }
      }
   }
}
