using LosevD_GUN39_GUNPC.Builders;
using LosevD_GUN39_GUNPC.Factories;

namespace LosevD_GUN39_GUNPC.Utils
{
   public class GameSetupResolver
   {
      public GameSetup Resolve(Difficulty difficulty)
      {
         switch (difficulty)
         {
            case Difficulty.Easy:
               return new GameSetup(new EasyUnitFactory(), new EasyDungeonBuilder());
            case Difficulty.Medium:
               return new GameSetup(new MediumUnitFactory(), new MediumDungeonBuilder());
            case Difficulty.Hard:
               return new GameSetup(new HardUnitFactory(), new HardDungeonBuilder());
            default:
               return new GameSetup(new EasyUnitFactory(), new EasyDungeonBuilder());
         }
      }
   }
}
