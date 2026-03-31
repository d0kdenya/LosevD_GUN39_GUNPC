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

      public int Damage { get; }

      public float Armor { get; }

      public Unit() : this("Unknown Unit")
      {
      }

      public Unit(string name)
      {
         Name = name;
         Damage = 5;
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
