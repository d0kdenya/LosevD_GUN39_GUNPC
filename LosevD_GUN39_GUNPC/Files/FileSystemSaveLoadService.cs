using System.IO;

namespace LosevD_GUN39_GUNPC.Files
{
   public sealed class FileSystemSaveLoadService : ISaveLoadService<string>
   {
      private string _path;

      public FileSystemSaveLoadService(string path)
      {
         string fullPath = Directory.GetCurrentDirectory() + $"\\{path}";

         if (!Directory.Exists(fullPath))
         {
            Directory.CreateDirectory(fullPath);
         }
         _path = fullPath;
      }

      public void SaveData(string data, string id)
      {
         string fullPath = GetFullPath(id);

         File.AppendAllText(fullPath, $"{data}\n");
      }

      public void SaveProfile(string data, string id)
      {
         string fullPath = GetFullPath(id);

         string[] parts = data.Split('\n');

         using (StreamWriter stream = File.CreateText(fullPath))
         {
            foreach (string part in parts)
            {
               stream.WriteLine(part);
            }
         }
         
      }

      public string LoadData(string id)
      {
         string fullPath = GetFullPath(id);

         try
         {
            using var stream = File.OpenText(fullPath);

            return stream.ReadToEnd();
         }
         catch
         {
            return "";
         }
         
      }

      private string GetFullPath(string id)
      {
         string fileName = $"{id}.txt";

         return Path.Combine(_path, fileName);
      }
   }
}
