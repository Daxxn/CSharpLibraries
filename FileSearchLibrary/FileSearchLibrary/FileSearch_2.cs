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
      //public static string[] FilterFiles(
      //   string[] initialDirectories,
      //   string[] excFiles = null,
      //   string[] excDirs = null,
      //   string[] fileFilters = null,
      //   string[] dirFilters = null
      //   )
      //{
      //   List<string> fileList = new List<string>();
      //   var directoryList = new List<string>(initialDirectories);

      //   foreach (var dir in directoryList)
      //   {
      //      fileList.AddRange(GetAllFiles(dir));
      //   }

      //   var filteredDirs = FilterFilePaths(fileList, dirFilters);
      //   var filteredFiles = FilterFilePaths(filteredDirs, fileFilters);
      //   var removedDirs = FilterFilePathsExclude(filteredFiles, excDirs);
      //   var removedFiles = FilterFilePathsExclude(removedDirs, excFiles);
      //   return removedFiles.ToArray();
      //}

      //private static List<string> FilterFilePathsExclude(List<string> allFiles, string[] excluded)
      //{
      //   if (excluded is null || excluded.Length <= 0 || allFiles.Count <= 0)
      //   {
      //      return allFiles;
      //   }
      //   List<string> newFiles = new List<string>();

      //   foreach (var file in allFiles)
      //   {
      //      string selectedFile = file;
      //      foreach (var excl in excluded)
      //      {
      //         if (file.Contains(excl))
      //         {
      //            selectedFile = null;
      //         }
      //      }

      //      if (selectedFile != null)
      //      {
      //         newFiles.Add(selectedFile);
      //      }
      //   }
      //   return newFiles;
      //}

      //private static List<string> FilterFilePaths(List<string> allFiles, string[] includeFilters = null)
      //{
      //   if (includeFilters is null || includeFilters.Length <= 0 || allFiles.Count <= 0)
      //   {
      //      return allFiles;
      //   }
      //   List<string> newFiles = new List<string>();
      //   foreach (var file in allFiles)
      //   {
      //      foreach (var exc in includeFilters)
      //      {
      //         if (file.Contains(exc))
      //         {
      //            newFiles.Add(file);
      //         }
      //      }
      //   }
      //   return newFiles;
      //}

      //private static string[] GetAllFiles(string path)
      //{
      //   if (Directory.Exists(path))
      //   {
      //      return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
      //   }
      //   else
      //   {
      //      return new string[0];
      //   }
      //}

      public static string[] FilterFiles(string rootPath, string[] excludedFiles, string[] excludedDirs)
      {
         try
         {
            List<string> filteredFiles = new List<string>();
            string[] files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
               string tempFile = null;
               foreach (var excl in excludedDirs)
               {
                  if (!file.Contains(excl))
                  {
                     tempFile = file;
                  }
               }

               foreach (var excl in excludedFiles)
               {
                  if (file.Contains(excl))
                  {
                     tempFile = null;
                  }
               }

               if (tempFile != null)
               {
                  filteredFiles.Add(tempFile);
               }
            }
            return filteredFiles.ToArray();
         }
         catch (Exception)
         {
            throw;
         }
      }

      public static string[] FilterFiles(string[] files, string[] excludedFiles, string[] excludedDirs)
      {
         try
         {
            List<string> filteredFiles = new List<string>();
            foreach (var file in files)
            {
               string tempFile = file;
               foreach (var exclDir in excludedDirs)
               {
                  if (file.Contains(exclDir))
                  {
                     tempFile = null;
                     break;
                  }
               }

               if (tempFile != null)
               {
                  foreach (var exclFile in excludedFiles)
                  {
                     if (file.Contains(exclFile))
                     {
                        tempFile = null;
                        break;
                     }
                  }
                  if (tempFile != null)
                  {
                     filteredFiles.Add(file);
                  }
               }
            }
            return filteredFiles.ToArray();
         }
         catch (Exception)
         {
            throw;
         }
      }

      public static string[] GetFiles(string rootDir, string[] otherDirs)
      {
         try
         {
            List<string> files = Directory.GetFiles(rootDir, "*.*", SearchOption.AllDirectories).ToList();

            foreach (var dir in otherDirs)
            {
               files.AddRange(Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories));
            }

            return files.ToArray();
         }
         catch (Exception)
         {
            throw;
         }
      }

      public static string[] GetFiles(string path, string filter)
      {
         return Directory.GetFiles(path, filter, SearchOption.AllDirectories);
      }

      public static string[] GetFiles(string[] dirs, string filter)
      {
         List<string> files = new List<string>();
         foreach (var dir in dirs)
         {
            files.AddRange(Directory.GetFiles(dir, filter));
         }
         return files.ToArray();
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
