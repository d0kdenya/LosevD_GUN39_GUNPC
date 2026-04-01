using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Items.EquipItems
{
   public sealed class Weapon : EquipItem
   {
      public uint Damage { get; }

      public Weapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

      public override EquipSlot Slot => EquipSlot.Weapon;

   }
}
