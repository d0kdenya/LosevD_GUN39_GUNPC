using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Items.EquipItems
{
   public abstract class EquipItem : Item
   {
      private uint _durability;

      private uint _maxDurability;

      public uint Duralibity { get => _durability; set => _durability = value; }
      
      public override bool Stackable => false;

      public abstract EquipSlot Slot { get; }

      protected EquipItem(uint maxDurability, string name) : base(name) => _maxDurability = maxDurability;

      public void Repair(uint delta) =>
         _durability += _durability + delta > _maxDurability
         ? _maxDurability
         : _durability + delta;
   }
}
