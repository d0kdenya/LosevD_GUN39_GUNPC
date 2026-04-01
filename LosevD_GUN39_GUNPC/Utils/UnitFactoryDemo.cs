using LosevD_GUN39_GUNPC.Items.EquipItems;
using LosevD_GUN39_GUNPC.Units;

namespace LosevD_GUN39_GUNPC.Utils
{
   public class UnitFactoryDemo
   {
      public static Unit CreatePlayer(string name)
      {
         Player player = new Player(name, 30, 30, 6);
         player.AddItemToInventory(new Weapon(10, 15, "Sword"));
         player.AddItemToInventory(new Armour(10, 15, "Armour"));
         return player;
      }

      public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);
   }
}
