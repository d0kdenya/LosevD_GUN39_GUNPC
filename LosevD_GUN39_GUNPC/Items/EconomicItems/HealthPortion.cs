namespace LosevD_GUN39_GUNPC.Items.EconomicItems
{
   public sealed class HealthPortion : EconomicItem
   {
      public uint HealthRestore => 7;

      public override bool Stackable => false;

      public HealthPortion(string name) : base(name)
      {
      }
   }
}
