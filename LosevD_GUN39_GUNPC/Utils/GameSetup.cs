using LosevD_GUN39_GUNPC.Interfaces;

namespace LosevD_GUN39_GUNPC.Utils
{
   public sealed class GameSetup
   {
      public IUnitFactory UnitFactory { get; }
      public IDungeonBuilder DungeonBuilder { get; }

      public GameSetup(IUnitFactory unitFactory, IDungeonBuilder dungeonBuilder)
      {
         UnitFactory = unitFactory;
         DungeonBuilder = dungeonBuilder;
      }
   }
}
