using LosevD_GUN39_GUNPC.Dungeon;
using LosevD_GUN39_GUNPC.Units;

namespace LosevD_GUN39_GUNPC.Utils
{
   public static class GameCommands
   {
      public static void PrintPlayerInfo(Unit player)
      {
         Console.WriteLine($"\n{player.ToString()}\n");
      }

      public static void PrintPlayerInventory(Unit player, int index)
      {
         if (index != -1)
         {
            var item = player.GetInventoryItem(index);
            if (item != null)
            {
               Console.WriteLine($"Item: {item.Name}, Amount: {item.Amount}");
            }
         }
         else
         {
            var items = player.GetInventory();
            foreach (var item in items)
            {
               Console.WriteLine($"Item: {item.Name}, Amount: {item.Amount}");
            }
         }
      }

      public static void PrintGameOver(Unit player)
      {
         Console.WriteLine("\nGame over!");
         Console.WriteLine("Result: ");
         Console.WriteLine(player.ToString());
      }

      public static bool TryGoNextRoom(ref DungeonRoom _currentRoom, string args)
      {
         if (Enum.TryParse<Direction>(args, ignoreCase: true, out var direction))
         {
            if (!_currentRoom.Rooms.ContainsKey(direction))
            {
               Console.WriteLine("\nWrong direction!\n");
               return false;
            }
            _currentRoom = _currentRoom.Rooms[direction];
            return true;
         }
         Console.WriteLine("\nWrong direction!\n");
         return false;
      }
   }
}
