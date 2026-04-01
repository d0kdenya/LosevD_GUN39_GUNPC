using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Items.EconomicItems
{
   public sealed class Gold : EconomicItem
   {
      public override bool Stackable => false;

      public Gold() : base(GameConstants.Gold)
      {
      }
   }
}
