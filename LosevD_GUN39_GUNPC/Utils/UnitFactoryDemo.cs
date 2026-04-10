using LosevD_GUN39_GUNPC.Items.EquipItems;
using LosevD_GUN39_GUNPC.Units;

namespace LosevD_GUN39_GUNPC.Utils
{
   public class UnitFactoryDemo
   {
      public static Unit CreatePlayer(string name)
      {
         Player player = new Player(name, 30, 30, 6);

         Weapon sword = new Sword(8, 15, 15, "Sword");
         Weapon bow = new Bow(12, 16, 5, 15, "Bow");
         Armour armour = new Armour(10, 15, "Armour");
         Helmet helmet = new Helmet(8, 12, "Helmet");

         player.OnDeath += () => Console.WriteLine("Game over!");

         player.AddItemToInventory(sword);
         player.AddItemToInventory(armour);

         return player;
      }

      public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);
   }
}
