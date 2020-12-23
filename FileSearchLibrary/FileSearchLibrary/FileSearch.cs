using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSearchLibrary
{
   /// <summary>
   /// OLD
   /// </summary>
   public static class FileSearch
   {
      #region - Fields & Properties

      #endregion

      #region - Methods
      public static string[] FindFiles(
         string rootDirectory,
         string[] directoryParams,
         string[] fileParams,
         string[] extParams
         )
      {
         string[] files = Directory.GetFiles(rootDirectory, "*.*", SearchOption.AllDirectories);

         if (files.Length == 0)
         {
            throw new Exception("No files found.");
         }

         string[] filteredDir = FilterFiles(files, directoryParams).ToArray();
         string[] filteredFiles = FilterFiles(filteredDir, fileParams).ToArray();
         return FilterFiles(filteredFiles, extParams).ToArray();
      }

      private static IEnumerable<string> FilterFiles(IEnumerable<string> files, string[] searchParams)
      {
         List<string> output = new List<string>();
         if (searchParams.Length == 0)
         {
            return files;
         }
         foreach (var file in files)
         {
            foreach (var param in searchParams)
            {
               if (file.Contains(param))
               {
                  output.Add(file);
               }
            }
         }
         return output;
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
