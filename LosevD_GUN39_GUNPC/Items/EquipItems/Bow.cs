namespace LosevD_GUN39_GUNPC.Items.EquipItems
{
   internal class Bow : Weapon
   {
      public uint ArrowsCount { get; set; }

      public Bow(uint damage, uint maxDamage, uint arrowsCount, uint durability, string name) : base(damage, maxDamage, durability, name)
      {
         ArrowsCount = arrowsCount;
      }
   }
}
