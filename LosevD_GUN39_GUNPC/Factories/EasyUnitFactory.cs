using LosevD_GUN39_GUNPC.Interfaces;
using LosevD_GUN39_GUNPC.Items.EquipItems;
using LosevD_GUN39_GUNPC.Units;
using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Factories
{
   public sealed class EasyUnitFactory : IUnitFactory
   {
      public Unit CreatePlayer(string name)
      {
         Player player = new Player(name, 60, 60, 12);

         Sword sword = new Sword(8, 15, 15, "Sword");
         Armour armour = new Armour(10, 15, "Armour");
         Helmet helmet = new Helmet(8, 12, "Helmet");

         player.OnDeath += () => Console.WriteLine("Game over!");

         player.AddItemToInventory(sword);
         player.AddItemToInventory(armour);
         player.AddItemToInventory(helmet);

         return player;
      }

      public Unit CreateBasicEnemy() => new Goblin(GameConstants.Goblin, 10, 10, 2);
   }
}
