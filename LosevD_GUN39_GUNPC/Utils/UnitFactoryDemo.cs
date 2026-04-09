using LosevD_GUN39_GUNPC.Items.EquipItems;
using LosevD_GUN39_GUNPC.Units;

namespace LosevD_GUN39_GUNPC.Utils
{
   public class UnitFactoryDemo
   {
      public static Unit CreatePlayer(string name)
      {
         Player player = new Player(name, 30, 30, 6);

         Weapon weapon = new Weapon(8, 15, 15, "Sword");
         Armour armour = new Armour(10, 15, "Armour");

         player.OnDeath += () => Console.WriteLine("Game over!");

         player.AddItemToInventory(weapon);
         player.AddItemToInventory(armour);

         return player;
      }

      public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);
   }
}
