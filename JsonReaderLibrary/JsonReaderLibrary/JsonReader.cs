using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace JsonReaderLibrary
{
   public static class JsonReader
   {
      #region - Fields & Properties
      public static JsonSerializerSettings SerializeSettings { get; set; } = new JsonSerializerSettings
      {
         TypeNameHandling = TypeNameHandling.Objects,
         TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
         Formatting = Formatting.Indented,
      };
      public static JsonSerializerSettings DeserializerSettings { get; set; } = new JsonSerializerSettings
      {
         TypeNameHandling = TypeNameHandling.Objects,
      };
      #endregion

      #region - Methods
      /// <summary>
      /// Saves the object to the provided path.
      /// </summary>
      /// <typeparam name="TModel">The type of object, infered from the data property.</typeparam>
      /// <param name="path">The path to the file.</param>
      /// <param name="data">The data to save.</param>
      /// <param name="createNew">Will create a new file if true.</param>
      /// <param name="autoIndent">Saves indented.</param>
      public static void SaveJsonFile<TModel>(
         string path,
         TModel data,
         bool createNew = false,
         bool autoIndent = true
      ) where TModel : new()
      {
         try
         {
            if (String.IsNullOrEmpty(path))
            {
               throw new ArgumentException($"Path cannot be empty: '{path}'");
            }

            if (!File.Exists(path) && !createNew)
            {
               throw new ArgumentException($"Path is not a file: '{path}'");
            }

            if (data is null)
            {
               throw new ArgumentException($"Provided data cannot be null.");
            }

            if (createNew)
            {
               SerializeSettings.Formatting = autoIndent ? Formatting.Indented : Formatting.None;
               using StreamWriter writer = new StreamWriter(path);
               string json = JsonConvert.SerializeObject(data, SerializeSettings);
               writer.Write(json);
               writer.Flush();
            }

         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Saves the object to the provided path asynchronously.
      /// </summary>
      /// <typeparam name="TModel">The type of object, infered from the data property.</typeparam>
      /// <param name="path">The path to the file.</param>
      /// <param name="data">The data to save.</param>
      /// <param name="createNew">Will create a new file if true.</param>
      /// <param name="autoFormat">Saves indented.</param>
      /// <returns>A <see cref="Task"/> operation</returns>
      public static async Task SaveJsonFileAsync<TModel>(
         string path,
         TModel data,
         bool createNew = false,
         bool autoFormat = true
      ) where TModel : new()
      {
         try
         {
            await Task.Run(() =>
            {
               SaveJsonFile(path, data, createNew, autoFormat);
            });
         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Opens the file and parses it with the provided type.
      /// </summary>
      /// <typeparam name="TModel">The type to convert the Json to.</typeparam>
      /// <param name="path">The path to the file.</param>
      /// <returns>The object as the <typeparamref name="TModel"/></returns>
      public static TModel OpenJsonFile<TModel>(string path)
      {
         try
         {
            if (String.IsNullOrEmpty(path))
            {
               throw new ArgumentException($"Path cannot be empty: '{path}'");
            }

            if (!File.Exists(path))
            {
               throw new ArgumentException($"Path is not a file: '{path}'");
            }

            using StreamReader reader = new StreamReader(path);
            return JsonConvert.DeserializeObject<TModel>(reader.ReadToEnd(), DeserializerSettings);
         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Opens a file async asynchronously.
      /// </summary>
      /// <typeparam name="TModel">The type to convert the Json to.</typeparam>
      /// <param name="path">The path to the file.</param>
      /// <returns>The object as the <see cref="Task"/> <typeparamref name="TModel"/></returns>
      public static async Task<TModel> OpenJsonFileAsync<TModel>(string path)
      {
         try
         {
            return await Task.Run(() =>
            {
               return OpenJsonFile<TModel>(path);
            });
         }
         catch (Exception)
         {
            throw;
         }
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
