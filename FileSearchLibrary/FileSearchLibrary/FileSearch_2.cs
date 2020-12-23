using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSearchLibrary
{
   /// <summary>
   /// Searches all files and removes unwanted files.
   /// </summary>
   public static class FileSearch_2
   {
      #region - Methods
      public static string[] FilterFiles(
         string[] initialDirectories,
         string[] excFiles = null,
         string[] excDirs = null,
         string[] fileFilters = null,
         string[] dirFilters = null
         )
      {
         List<string> fileList = new List<string>();
         var directoryList = new List<string>(initialDirectories);

         foreach (var dir in directoryList)
         {
            fileList.AddRange(GetAllFiles(dir));
         }

         var filteredDirs = FilterFilePaths(fileList, dirFilters);
         var filteredFiles = FilterFilePaths(filteredDirs, fileFilters);
         var removedDirs = FilterFilePathsExclude(filteredFiles, excDirs);
         var removedFiles = FilterFilePathsExclude(removedDirs, excFiles);
         return removedFiles.ToArray();
      }

      private static List<string> FilterFilePathsExclude(List<string> allFiles, string[] excluded)
      {
         if (excluded is null || excluded.Length <= 0 || allFiles.Count <= 0)
         {
            return allFiles;
         }
         List<string> newFiles = new List<string>();

         foreach (var file in allFiles)
         {
            string selectedFile = file;
            foreach (var excl in excluded)
            {
               if (file.Contains(excl))
               {
                  selectedFile = null;
               }
            }

            if (selectedFile != null)
            {
               newFiles.Add(selectedFile);
            }
         }
         return newFiles;
      }

      private static List<string> FilterFilePaths(List<string> allFiles, string[] includeFilters = null)
      {
         if (includeFilters is null || includeFilters.Length <= 0 || allFiles.Count <= 0)
         {
            return allFiles;
         }
         List<string> newFiles = new List<string>();
         foreach (var file in allFiles)
         {
            foreach (var exc in includeFilters)
            {
               if (file.Contains(exc))
               {
                  newFiles.Add(file);
               }
            }
         }
         return newFiles;
      }

      private static string[] GetAllFiles(string path)
      {
         if (Directory.Exists(path))
         {
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
         }
         else
         {
            return new string[0];
         }
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
