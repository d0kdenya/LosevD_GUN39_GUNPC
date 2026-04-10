using LosevD_GUN39_GUNPC.Dungeon;
using LosevD_GUN39_GUNPC.Interfaces;
using LosevD_GUN39_GUNPC.Items.EconomicItems;

namespace LosevD_GUN39_GUNPC.Builders
{
   public sealed class HardDungeonBuilder : IDungeonBuilder
   {
      public DungeonRoom BuildDungeon(IUnitFactory unitFactory)
      {
         DungeonRoom enter = new DungeonRoom("Enter");
         var enemyOne = unitFactory.CreateBasicEnemy();
         var enemyTwo = unitFactory.CreateBasicEnemy();
         var enemyThre = unitFactory.CreateBasicEnemy();
         var enemyFour = unitFactory.CreateBasicEnemy();
         DungeonRoom monsterRoomOne = new DungeonRoom("Monster 1", enemyOne);
         DungeonRoom monsterRoomTwo = new DungeonRoom("Monster 2", enemyTwo);
         DungeonRoom monsterRoomThree = new DungeonRoom("Monster 3", enemyThre);
         DungeonRoom monsterRoomFour = new DungeonRoom("Monster 4", enemyFour);
         DungeonRoom emptyRoom = new DungeonRoom("Empty");
         DungeonRoom lootRoomOne = new DungeonRoom("Loot 1", new Gold());
         DungeonRoom lootRoomTwo = new DungeonRoom("Loot 2", new Gold());
         DungeonRoom finalRoom = new DungeonRoom("Final", new GrindStone("Stone 1"));

         enter.TrySetDirection(Direction.Right, monsterRoomOne);
         enter.TrySetDirection(Direction.Left, emptyRoom);

         monsterRoomOne.TrySetDirection(Direction.Forward, lootRoomOne);
         monsterRoomOne.TrySetDirection(Direction.Left, monsterRoomTwo);

         monsterRoomTwo.TrySetDirection(Direction.Forward, lootRoomTwo);
         monsterRoomTwo.TrySetDirection(Direction.Left, emptyRoom);

         emptyRoom.TrySetDirection(Direction.Forward, monsterRoomThree);

         lootRoomOne.TrySetDirection(Direction.Forward, finalRoom);
         monsterRoomThree.TrySetDirection(Direction.Forward, monsterRoomFour);

         monsterRoomFour.TrySetDirection(Direction.Forward, finalRoom);
         lootRoomTwo.TrySetDirection(Direction.Forward, finalRoom);

         return enter;
      }
   }
}
