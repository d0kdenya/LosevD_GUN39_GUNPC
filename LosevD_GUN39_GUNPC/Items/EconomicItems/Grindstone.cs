using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Items.EconomicItems
{
   public sealed class GrindStone : EconomicItem
   {
      public uint GrindPower => 3;

      public override bool Stackable => false;

      public GrindStone(string name) : base(name)
      {
      }
   }
}
