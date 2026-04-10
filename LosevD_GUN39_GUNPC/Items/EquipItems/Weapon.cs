using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Items.EquipItems
{
   public class Weapon : EquipItem
   {
      public uint Damage { get; }
      public uint MaxDamage { get; }

      public Weapon(uint damage, uint maxDamage, uint durability, string name) : base(durability, name)
      {
         Damage = damage;
         MaxDamage = maxDamage;
      }

      public override EquipSlot Slot => EquipSlot.Weapon;
   }
}
