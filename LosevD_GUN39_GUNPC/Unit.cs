namespace LosevD_GUN39_GUNPC
{
   internal class Unit
   {
      private string _name;
      private float _health;
      private int _damage;
      private float _armor;

      public string Name
      {
         get => _name;
      }

      public float Health
      {
         get => _health;
      }

      public int Damage
      {
         get => _damage;
      }

      public float Armor
      {
         get => _armor;
      }

      public Unit() : this("Unknown Unit")
      {
      }

      public Unit(string name)
      {
         _name = name;
         _damage = 5;
         _armor = 0.6f;
         _health = 20;
      }

      public float GetRealHealth()
      {
         return Health * (1f + Armor);
      }

      public bool SetDamage(int value)
      {
         float realDamage = value * Armor;

         _health = Health - realDamage;

         return Health <= 0f;
      }
   }
}
