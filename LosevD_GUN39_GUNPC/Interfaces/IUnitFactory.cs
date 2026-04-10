using LosevD_GUN39_GUNPC.Units;

namespace LosevD_GUN39_GUNPC.Interfaces
{
   public interface IUnitFactory
   {
      Unit CreatePlayer(string name);

      Unit CreateBasicEnemy();

      //Unit CreateEnemy(string enemyType);
   }
}
