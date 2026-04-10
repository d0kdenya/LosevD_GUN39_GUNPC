using LosevD_GUN39_GUNPC.Dungeon;
using LosevD_GUN39_GUNPC.Units;
using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Combat
{
   public sealed class CombatManager
   {
      private readonly Random _random = new();

      public CombatResult StartCombat(Unit player, Unit enemy, CommandParser parser, out string direction) => PlayCombatRoutine(player, enemy, parser, out direction);

      private CombatResult PlayCombatRoutine(Unit player, Unit enemy, CommandParser parser, out string direction)
      {
         direction = "";

         while (player.Health > 0 && enemy.Health > 0)
         {
            Console.WriteLine(GetCombatString());
            Console.Write("Your choice: ");

            var line = Console.ReadLine() ?? "";

            if (!parser.TryDispatch(line, out CommandResult commandResult, out string args))
            {
               if (Enum.TryParse<RockPaperScissors>(line, out var rockPaperScissors))
               {
                  HandleCombatInput(player, enemy, rockPaperScissors);
               }
               else
               {
                  Console.WriteLine(GetCombatString());
               }
            }
            else if (commandResult != CommandResult.ErrorCommand)
            {
               switch (commandResult)
               {
                  case CommandResult.Info:
                     GameCommands.PrintPlayerInfo(player);
                     break;
                  case CommandResult.Inventory:
                     if (int.TryParse(args, out int index))
                     {
                        GameCommands.PrintPlayerInventory(player, index);
                     }
                     else
                     {
                        GameCommands.PrintPlayerInventory(player, -1);
                     }
                     break;
                  case CommandResult.Go:
                     if (TryToEscapeFromBattle())
                     {
                        direction = args;
                        return CombatResult.Escaped;
                     }
                     else
                     {
                        break;
                     }
                  case CommandResult.Quit:
                     return CombatResult.QuitGame;
                  default:
                     break;
               }
            }
         }
         if (player.Health > 0 && enemy.Health == 0)
         {
            return CombatResult.PlayerWon;
         }
         if (player.Health == 0 && enemy.Health > 0)
         {
            return CombatResult.EnemyWon;
         }
         return CombatResult.UnknownResult;
      }

      private string GetCombatString() => $"\nType {RockPaperScissors.Rock} = {(int)RockPaperScissors.Rock}" +
         $" or {RockPaperScissors.Paper} = {(int)RockPaperScissors.Paper}" +
         $" or {RockPaperScissors.Scissors} = {(int)RockPaperScissors.Scissors}";

      private void HandleCombatInput(Unit player, Unit enemy, RockPaperScissors rockPaperScissors)
      {
         var enemyInput = (RockPaperScissors)_random.Next(1, 4);

         Console.WriteLine($"Result player = {rockPaperScissors} and enemy = {enemyInput}");

         switch (rockPaperScissors)
         {
            // player hit
            case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Scissors:
               ApplyDamage(player, enemy);
               break;
            case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Paper:
               ApplyDamage(player, enemy);
               break;
            case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Rock:
               ApplyDamage(player, enemy);
               break;
            // enemy hit
            case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Rock:
               ApplyDamage(enemy, player);
               break;
            case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Scissors:
               ApplyDamage(enemy, player);
               break;
            case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Paper:
               ApplyDamage(enemy, player);
               break;
            default:
               Console.WriteLine("Combatants tried to hit, but missed :(");
               break;
         }
      }

      private void ApplyDamage(Unit attacker, Unit defender)
      {
         defender.ApplyDamage(attacker.GetUnitDamage());
         Console.WriteLine($"{attacker.Name} hits {defender.Name}. {defender.Name} health {defender.Health}/{defender.MaxHealth}");

         if (defender.Health == 0)
         {
            Console.WriteLine($"{defender.Name} is dead!");
         }
      }

      private bool TryToEscapeFromBattle()
      {
         Console.WriteLine("Rolling your escape (33% chance)...");
         int roll = _random.Next(0, 21);

         Console.WriteLine($"Your roll from 0 to 20 = {roll}");

         if (roll == 0 || roll % 3 == 0)
         {
            return true;
            
         }
         else
         {
            Console.WriteLine("You can't escape! Continue battle :(");
            return false;
         }
      }
   }
}
