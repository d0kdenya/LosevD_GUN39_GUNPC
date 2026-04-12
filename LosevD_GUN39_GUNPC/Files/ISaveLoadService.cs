namespace LosevD_GUN39_GUNPC.Files
{
   public interface ISaveLoadService<T>
   {
      public void SaveData(T data, string id);

      public T LoadData(string id);
   }
}
