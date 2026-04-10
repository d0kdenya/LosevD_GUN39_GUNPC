using LosevD_GUN39_GUNPC.Dungeon;

namespace LosevD_GUN39_GUNPC.Interfaces
{
   public interface IDungeonBuilder
   {
      DungeonRoom BuildDungeon(IUnitFactory unitFactory);
   }
}
