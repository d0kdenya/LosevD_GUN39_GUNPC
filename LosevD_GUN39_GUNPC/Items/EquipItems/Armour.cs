using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Items.EquipItems
{
   public sealed class Armour : EquipItem
   {
      public uint Defence { get; }

      public Armour(uint defence, uint durability, string name) : base(durability, name) => Defence = defence;

      public override EquipSlot Slot => EquipSlot.Armour;
   }
}
