using LosevD_GUN39_GUNPC.Dungeon;
using LosevD_GUN39_GUNPC.Items.EconomicItems;

namespace LosevD_GUN39_GUNPC.Utils
{
   public sealed class DungeonBuilder
   {
      public static DungeonRoom BuildDungeon()
      {
         DungeonRoom enter = new DungeonRoom("Enter");
         DungeonRoom monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
         DungeonRoom emptyRoom = new DungeonRoom("Empty");
         DungeonRoom lootRoom = new DungeonRoom("Loot1", new Gold());
         DungeonRoom lootStoneRoom = new DungeonRoom("Loot1", new GrindStone("Stone1"));
         DungeonRoom finalRoom = new DungeonRoom("Final", new GrindStone("Stone 1"));

         enter.TrySetDirection(Direction.Right, monsterRoom);
         enter.TrySetDirection(Direction.Left, emptyRoom);

         monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
         monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

         emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

         lootRoom.TrySetDirection(Direction.Forward, finalRoom);
         lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

         return enter;
      }
   }
}
