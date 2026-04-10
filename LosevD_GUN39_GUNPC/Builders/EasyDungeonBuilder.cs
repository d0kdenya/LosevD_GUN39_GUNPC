using LosevD_GUN39_GUNPC.Dungeon;
using LosevD_GUN39_GUNPC.Interfaces;
using LosevD_GUN39_GUNPC.Items.EconomicItems;

namespace LosevD_GUN39_GUNPC.Builders
{
   public sealed class EasyDungeonBuilder : IDungeonBuilder
   {
      public DungeonRoom BuildDungeon(IUnitFactory unitFactory)
      {
         DungeonRoom enter = new DungeonRoom("Enter");
         var enemy = unitFactory.CreateBasicEnemy();
         DungeonRoom monsterRoom = new DungeonRoom("Monster", enemy);
         DungeonRoom emptyRoom = new DungeonRoom("Empty");
         DungeonRoom lootRoom = new DungeonRoom("Loot 1", new Gold());
         DungeonRoom lootStoneRoom = new DungeonRoom("Loot 2", new GrindStone("Stone 1"));
         DungeonRoom finalRoom = new DungeonRoom("Final", new GrindStone("Stone 2"));

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
