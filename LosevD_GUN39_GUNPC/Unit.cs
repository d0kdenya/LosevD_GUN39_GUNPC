namespace LosevD_GUN39_GUNPC
{
   internal class Unit
   {
      private float _health;

      public float Health
      {
         get => _health;
      }

      public string Name { get; }

      public Interval Damage { get; }

      public float Armor { get; }

      public Unit() : this("Unknown Unit")
      {
      }

      public Unit(string name)
      {
         Name = name;
         Damage = new Interval(0, 5);
         Armor = 0.6f;
         _health = 20;
      }

      public Unit(string name, int minDamage, int maxDamage)
      {
         Name = name;
         Damage = new Interval(minDamage, maxDamage);
         Armor = 0.6f;
         _health = 20;
      }

      public float GetRealHealth()
      {
         return Health * (1f + Armor);
      }

      public bool SetDamage(int damage)
      {
         _health -= damage * Armor;

         return Health <= 0f;
      }
   }
}
