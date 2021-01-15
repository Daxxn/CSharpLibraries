using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataTypeLibrary
{
   public struct Gravity
   {
      public const double GConstant = 9.81;

      public double GravMultiplyer { get; set; }
      public bool IsGRelative { get; set; }

      public Gravity(double grav, bool isGBased = true)
      {
         GravMultiplyer = isGBased ? grav : GConstant * grav;
         IsGRelative = isGBased;
      }

      public double ToAcceleration()
      {
         return GravMultiplyer * GConstant;
      }
   }
}
