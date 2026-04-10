using LosevD_GUN39_GUNPC.Dungeon;
using LosevD_GUN39_GUNPC.Interfaces;
using LosevD_GUN39_GUNPC.Items.EconomicItems;

namespace LosevD_GUN39_GUNPC.Builders
{
   public sealed class MediumDungeonBuilder : IDungeonBuilder
   {
      public DungeonRoom BuildDungeon(IUnitFactory unitFactory)
      {
         DungeonRoom enter = new DungeonRoom("Enter");
         var enemyOne = unitFactory.CreateBasicEnemy();
         var enemyTwo = unitFactory.CreateBasicEnemy();
         DungeonRoom monsterRoomOne = new DungeonRoom("Monster 1", enemyOne);
         DungeonRoom monsterRoomTwo = new DungeonRoom("Monster 2", enemyTwo);
         DungeonRoom emptyRoom = new DungeonRoom("Empty");
         DungeonRoom lootRoomOne = new DungeonRoom("Loot 1", new Gold());
         DungeonRoom lootRoomTwo = new DungeonRoom("Loot 2", new Gold());
         DungeonRoom lootStoneRoom = new DungeonRoom("Loot 3", new GrindStone("Stone 1"));
         DungeonRoom finalRoom = new DungeonRoom("Final", new GrindStone("Stone 2"));

         enter.TrySetDirection(Direction.Right, monsterRoomOne);
         enter.TrySetDirection(Direction.Left, emptyRoom);

         monsterRoomOne.TrySetDirection(Direction.Forward, lootRoomOne);
         monsterRoomOne.TrySetDirection(Direction.Left, monsterRoomTwo);

         monsterRoomTwo.TrySetDirection(Direction.Forward, lootRoomTwo);
         monsterRoomTwo.TrySetDirection(Direction.Left, emptyRoom);

         emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

         lootRoomOne.TrySetDirection(Direction.Forward, finalRoom);
         lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);
         lootRoomTwo.TrySetDirection(Direction.Forward, finalRoom);

         return enter;
      }
   }
}
