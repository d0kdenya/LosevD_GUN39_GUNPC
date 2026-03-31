namespace LosevD_GUN39_GUNPC
{
   internal class Weapon
   {
      public string Name { get; }

      public Interval Damage { get; private set; }

      public float Durability { get; }

      public Weapon(string name)
      {
         Name = name;
         Durability = 1f;
      }

      public Weapon(string name, int minDamage, int maxDamage) : this(name)
      {
         SetDamageParams(minDamage, maxDamage);
      }

      public void SetDamageParams(int minDamage, int maxDamage)
      {
         if (minDamage < 1)
         {
            minDamage = 1;
            
            Console.WriteLine("Форсированная установка минимального значения урона для оружия = {0}!", Name);
         }
         if (maxDamage <= 1)
         {
            maxDamage = 10;

            Console.WriteLine("Форсированная установка максимального значения урона для оружия = {0}!", Name);
         }
         if (minDamage > maxDamage)
         {
            int tmp = minDamage;
            minDamage = maxDamage;
            maxDamage = tmp;

            Console.WriteLine("Некорректные входные данные для оружия = {0}!", Name);
         }

         Damage = new Interval(minDamage, maxDamage);
      }

      public int GetDamage()
      {
         return (Damage.Min + Damage.Max) / 2;
      }
   }
}
