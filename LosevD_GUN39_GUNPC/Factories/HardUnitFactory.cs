using LosevD_GUN39_GUNPC.Interfaces;
using LosevD_GUN39_GUNPC.Items.EquipItems;
using LosevD_GUN39_GUNPC.Units;
using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Factories
{
   public sealed class HardUnitFactory : IUnitFactory
   {
      public Unit CreatePlayer(string name)
      {
         Player player = new Player(name, 100, 100, 2);

         Bow bow = new Bow(5, 10, 10, 10, "Bow");
         Armour armour = new Armour(10, 15, "Armour");

         player.OnDeath += () => Console.WriteLine("Game over!");

         player.AddItemToInventory(bow);
         player.AddItemToInventory(armour);

         return player;
      }

      public Unit CreateBasicEnemy() => new Goblin(GameConstants.Goblin, 60, 60, 5);
   }
}
