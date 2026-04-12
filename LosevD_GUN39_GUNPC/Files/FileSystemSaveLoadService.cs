namespace LosevD_GUN39_GUNPC.Files
{
   public sealed class FileSystemSaveLoadService : ISaveLoadService<string>
   {
      private string _path;

      public FileSystemSaveLoadService(string path)
      {
         if (!Directory.Exists(path))
         {
            Directory.CreateDirectory(path);
         }
         _path = path;
      }

      public void SaveData(string data, string id)
      {
         string fullPath = GetFullPath(id);

         using (StreamWriter stream = File.CreateText(fullPath))
         {
            stream.Write(data);
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
