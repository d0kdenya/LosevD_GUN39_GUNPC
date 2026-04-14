namespace LosevD_GUN39_GUNPC.Profiles
{
   public sealed class Player
   {
      public string Name { get; }

      public uint Balance { get; set; }

      public Player(string name, uint balance)
      {
         Name = name;
         Balance = balance;
      }

      public override string? ToString()
      {
         return $"{Name} {Balance}";
      }
   }
}
