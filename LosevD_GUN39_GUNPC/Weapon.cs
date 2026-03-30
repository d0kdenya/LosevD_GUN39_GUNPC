namespace LosevD_GUN39_GUNPC
{
   internal class Weapon
   {
      private string _name;
      private int _minDamage;
      private int _maxDamage;
      private float _durability;

      public string Name
      {
         get => _name;
      }

      public int MinDamage
      {
         get => _minDamage;
         private set => _minDamage = value;
      }

      public int MaxDamage
      {
         get => _maxDamage;
         private set => _maxDamage = value;
      }

      public float Durability
      {
         get => _durability;
      }

      public Weapon(string name)
      {
         _name = name;
         _durability = 1f;
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

         MinDamage = minDamage;
         MaxDamage = maxDamage;
      }

      public int GetDamage()
      {
         return (MinDamage + MaxDamage) / 2;
      }
   }
}
