using LosevD_GUN39_GUNPC.Items;
using LosevD_GUN39_GUNPC.Units;

namespace LosevD_GUN39_GUNPC.Dungeon
{
   public sealed class DungeonRoom
   {
      public HashSet<Item> Loot { get; }

      public readonly string Name;

      public readonly Unit? Enemy;

      public readonly Dictionary<Direction, DungeonRoom> Rooms = new();

      public bool IsFinal => Rooms.Count == 0;

      public DungeonRoom(string name)
      {
         Name = name;
         Loot = new HashSet<Item>();
      }

      public DungeonRoom(string name, Unit enemy)
      {
         Name = name;
         Enemy = enemy;
         Loot = new HashSet<Item>();
      }

      public DungeonRoom(string name, Item item)
      {
         Name = name;
         Loot = new HashSet<Item>() { item };
      }

      public bool TrySetDirection(Direction direction, DungeonRoom room)
      {
         if (Rooms.ContainsKey(direction))
         {
            Console.WriteLine($"Room {Name} already has room for {direction.ToString()}");
            return false;
         }
         Rooms.Add(direction, room);
         return true;
      }
   }
}
