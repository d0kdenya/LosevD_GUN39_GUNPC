namespace LosevD_GUN39_GUNPC
{
   internal struct Room
   {
      public Unit Unit { get; }
      public Weapon Weapon { get; }

      public Room(Unit unit, Weapon weapon)
      {
         Unit = unit;
         Weapon = weapon;
      }
   }
}
