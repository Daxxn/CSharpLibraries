using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataTypeLibrary
{
   public enum Measurement
   {
      Meter,
      Gram,
      Liter,
      SqMeter,
      CuMeter
   }
   public enum Prefix
   {
      Peta = 15,
      Tera = 12,
      Giga = 9,
      Mega = 6,
      Kilo = 3,
      Hecto = 2,
      Deka = 1,
      Base = 0,
      Deci = -1,
      Centi = -2,
      Milli = -3,
      Micro = -6,
      Nano = -9,
      Angs = -10,
      Pico = -12,
   }
   public class Metric
   {
      #region - Fields & Properties
      public static readonly Metric Infinity = new Metric(Double.PositiveInfinity);
      private double _value;
      private double _fullValue;
      public Prefix Prefix { get; set; } = Prefix.Base;
      public Measurement Measurement { get; set; } = Measurement.Meter;
      #endregion

      #region - Constructors
      public Metric(double fullValue)
      {
         SetFullValue(fullValue);
      }
      public Metric(double fullValue, Measurement measurement)
      {
         SetFullValue(fullValue);
      }
      public Metric(double value, Prefix prefix)
      {
         SetValue(value, prefix);
      }
      public Metric(double value, Prefix prefix, Measurement measurement)
      {
         SetValue(value, prefix);
         Measurement = measurement;
      }

      #endregion
      #region - Methods
      public override string ToString()
      {
         if (FullValue == 0)
         {
            return $"0 {Measurement}";
         }
         else
         {
            return $"{Value} {(Prefix == 0 ? "" : Prefix.ToString())}{Measurement}{(Value > 1 || Value < 1 ? "s" : "")}";
         }
      }

      public void SetValue(double value, Prefix prefix)
      {
         _value = value;
         Prefix = prefix;
         FullValue = GetFullValueFromPrefix(value);
      }
      public void SetFullValue(double value)
      {
         _fullValue = value;
         Prefix = GetPrefix(value);
         Value = GetValueFromPrefix(value);
      }
      private double GetFullValueFromPrefix(double fullValue)
      {
         return Math.Pow(10, (int)Prefix) * fullValue;
      }

      private double GetValueFromPrefix(double value)
      {
         if (value != 0)
         {
            if (value > 0)
            {
               return value / Math.Pow(10, (int)Prefix);
            }
            else
            {
               return value / Math.Pow(10, (int)Prefix);
            }
         }
         else
         {
            return 0;
         }
      }

      private static Prefix GetPrefix(double value)
      {
         if (value > 0)
         {
            return (Prefix)Math.Floor(Math.Log10(value));
         }
         else if (value < 0)
         {
            var newPrefix = Math.Floor(Math.Log10(Math.Abs(value)));
            return (Prefix)newPrefix;
         }
         else
         {
            return Prefix.Base;
         }
      }

      #region Operator Methods
      public static Metric operator +(Metric x, Metric y)
      {
         if (x.Measurement == y.Measurement)
         {
            return new Metric(x.FullValue + y.FullValue, x.Measurement);
         }
         else
         {
            throw new ArgumentException("Measurement types must match.");
         }
      }

      public static Metric operator -(Metric x, Metric y)
      {
         if (x.Measurement == y.Measurement)
         {
            return new Metric(x.FullValue - y.FullValue, x.Measurement);
         }
         else
         {
            throw new ArgumentException("Measurement types must match.");
         }
      }

      public static Metric operator *(Metric x, Metric y)
      {
         if (x.Measurement == y.Measurement)
         {
            return new Metric(x.FullValue * y.FullValue, x.Measurement);
         }
         else
         {
            throw new ArgumentException("Measurement types must match.");
         }
      }

      public static Metric operator /(Metric x, Metric y)
      {
         if (x.Measurement == y.Measurement)
         {
            return new Metric(x.FullValue / y.FullValue, x.Measurement);
         }
         else
         {
            throw new ArgumentException("Measurement types must match.");
         }
      }
      #endregion
      #endregion

      #region - Full Properties
      public double Value
      {
         get { return _value; }
         private set
         {
            _value = value;
         }
      }
      public double FullValue
      {
         get
         {
            return _fullValue;
         }
         set
         {
            SetFullValue(value);
         }
      }
      #endregion
   }
}
