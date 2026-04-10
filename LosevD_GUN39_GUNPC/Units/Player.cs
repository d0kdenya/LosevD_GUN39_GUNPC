using LosevD_GUN39_GUNPC.Items;
using LosevD_GUN39_GUNPC.Items.EconomicItems;
using LosevD_GUN39_GUNPC.Items.EquipItems;
using LosevD_GUN39_GUNPC.Utils;
using System.Text;

namespace LosevD_GUN39_GUNPC.Units
{
   public sealed class Player : Unit
   {
      private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

      private readonly Random _random = new();

      public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
      {
      }

      public override uint GetUnitDamage()
      {
         uint damage = 0;

         if (_equipment.TryGetValue(EquipSlot.Weapon, out var item))
         {
            if (item is Sword sword)
            {
               sword.Durability--;
               if (sword.Durability == 0)
               {
                  RemoveItemFromInventory(sword);
               }
               damage = (uint)_random.Next((int)sword.Damage, (int)sword.MaxDamage);
            }
            else if (item is Bow bow)
            {
               bow.Durability--;
               bow.ArrowsCount--;
               if (bow.Durability == 0 || bow.ArrowsCount == 0)
               {
                  RemoveItemFromInventory(bow);
               }
               damage = (uint)_random.Next((int)bow.Damage, (int)bow.MaxDamage);
            }


            return BaseDamage + damage;
         }
         return BaseDamage;
      }

      public override void HandleCombatComplete()
      {
         var items = Inventory.Items;

         base.AddItemToInventory(new GrindStone(GameConstants.Grindstone));

         for (var i = 0; i < items.Count; i++)
         {
            if (items[i] is EconomicItem economicItem)
            {
               UseEconomicItem(economicItem);
               Inventory.TryRemove(items[i]);
            }
         }
      }

      public override void AddItemToInventory(Item item)
      {
         if (item is EquipItem equipItem && _equipment.TryAdd(equipItem.Slot, equipItem))
         {
            // Item was equipped
            return;
         }
         base.AddItemToInventory(item);
      }

      protected override uint CalculateAppliedDamage(uint damage)
      {
         uint defenceSum = 0;

         if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour)
         {
            armour.Durability--;
            if (armour.Durability == 0)
            {
               RemoveItemFromInventory(armour);
            }
            defenceSum += armour.Defence;
         }
         if (_equipment.TryGetValue(EquipSlot.Helmet, out item) && item is Helmet helmet)
         {
            helmet.Durability--;
            if (helmet.Durability == 0)
            {
               RemoveItemFromInventory(helmet);
            }
            defenceSum += helmet.Defence;
         }
         damage -= (uint)(damage * (defenceSum / 100f));

         return damage;
      }

      private void UseEconomicItem(EconomicItem economicItem)
      {
         if (economicItem is HealthPortion healthPortion)
         {
            Health += healthPortion.HealthRestore;
         }
         if (economicItem is GrindStone grindStone)
         {
            foreach(var kvp in _equipment)
            {
               kvp.Value.Repair(grindStone.GrindPower);
            }
         }
      }

      public override void RemoveItemFromInventory(Item item)
      {
         if (item is EquipItem equipItem && _equipment.TryGetValue(equipItem.Slot, out EquipItem value))
         {
            _equipment.Remove(equipItem.Slot);
            Console.WriteLine($"[{equipItem.Slot}] was broken!");
         }
         base.RemoveItemFromInventory(item);
      }

      public override Item GetInventoryItem(int index)
      {
         return base.GetInventoryItem(index);
      }

      public void ShowInventory(StringBuilder builder)
      {
         var items = Inventory.Items;
         for (int i = 0; i < items.Count; i++)
         {
            builder.Append($"[{items[i].Name}] : {items[i].Amount}");
         }
      }

      public EquipItem? GetEquippedItem(EquipSlot slot)
      {
         _equipment.TryGetValue(slot, out EquipItem? equipItem);

         return equipItem;
      }

      public void EquipOrReplace(EquipItem newItem)
      {
         EquipSlot slot = newItem.Slot;

         if (_equipment.TryGetValue(slot, out EquipItem item))
         {
            Console.Write($"Item was replaced from {_equipment[slot].Name} ");
            _equipment[slot] = newItem;
            Console.Write($"to {newItem.Name}!");
         }
         else
         {
            _equipment.Add(slot, newItem);
            Console.Write($"Item {newItem.Name} was equipped!");
         }
      }

      public override string ToString()
      {
         StringBuilder builder = new StringBuilder();
         builder.AppendLine(Name);
         builder.AppendLine($"Health {Health}/{MaxHealth}");
         builder.AppendLine("Loot: ");

         ShowInventory(builder);

         return builder.ToString();
      }
   }
}
