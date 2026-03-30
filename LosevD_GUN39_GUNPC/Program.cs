namespace LosevD_GUN39_GUNPC
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Unit unit = new Unit("Knight");

         Console.WriteLine("Unit health = {0}, real health = {1}", unit.Health, unit.GetRealHealth());

         Console.WriteLine("Unit is alive? {0}", unit.SetDamage(10));
         Console.WriteLine("Unit is alive? {0}", unit.SetDamage(10));
         Console.WriteLine("Unit is alive? {0}", unit.SetDamage(20));

         Weapon weapon = new Weapon("Pistol", 5, 20);

         Console.WriteLine("Weapon damage: {0}", weapon.GetDamage());
      }
   }
}
