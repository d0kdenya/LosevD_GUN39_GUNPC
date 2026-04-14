using LosevD_GUN39_GUNPC.Files;
using LosevD_GUN39_GUNPC.Profiles;
using System.Collections.Generic;

namespace LosevD_GUN39_GUNPC.Game
{
   public sealed class Casino : IGame
   {
      private FileSystemSaveLoadService _fileSystem = new FileSystemSaveLoadService("Profiles");

      private DiceGame _diceGame = new DiceGame(10, 1, 6);

      private BlackjackGame _blackjackGame = new BlackjackGame(52);

      private Player _player = null!;

      private uint _casinoBalance = 100000;

      private const uint MaxPlayerBank = 50000;

      public void StartGame()
      {
         FirstSteps();

         while (true)
         {
            if (_casinoBalance == 0)
            {
               Console.WriteLine("You've ruined the casino, and a new one will be built in it's place!");
            }

            Console.WriteLine($"\n\tCurrent balance: {_player.Balance}$");
            Console.WriteLine("\nWhat you want?");
            Console.WriteLine("\t1 - Play Blackjack;");
            Console.WriteLine("\t2 - Play Dice;");
            Console.WriteLine("\t3 - Go home.");
            Console.Write("Your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
               int bet = 0;

               bool playerWon = false;

               Action onWin = () =>
               {
                  _player.Balance += (uint) bet;
                  Console.WriteLine($"You win {bet}$");
                  _casinoBalance -= (uint) bet;
                  playerWon = true;
               };
               Action onLoose = () =>
               {
                  _player.Balance -= (uint) bet;
                  Console.WriteLine($"You lose {bet}$");
                  _casinoBalance += (uint) bet;
               };
               Action onDraw = () =>
               {
                  Console.WriteLine("Draw!");
               };

               switch (choice)
               {
                  case 1:
                     if (_player.Balance == 0)
                     {
                        Console.WriteLine("No money? Kicked!");
                        return;
                     }
                     Console.WriteLine("\nWelcome to Blackjack Game!");

                     bet = PlaceBet();

                     _blackjackGame.OnWin += onWin;
                     _blackjackGame.OnLoose += onLoose;
                     _blackjackGame.OnDraw += onDraw;

                     _blackjackGame.PlayGame();

                     _blackjackGame.OnWin -= onWin;
                     _blackjackGame.OnLoose -= onLoose;
                     _blackjackGame.OnDraw -= onDraw;

                     if (playerWon)
                     {
                        ApplyPlayerBankRulesAfterWin();
                     }
                     ApplyBarRuleIfOverMax();

                     SaveGame();

                     break;
                  case 2:
                     if (_player.Balance == 0)
                     {
                        Console.WriteLine("No money? Kicked!");
                        return;
                     }
                     Console.WriteLine("\nWelcome to Dice Game!");

                     bet = PlaceBet();

                     _diceGame.OnWin += onWin;
                     _diceGame.OnLoose += onLoose;
                     _diceGame.OnDraw += onDraw;

                     _diceGame.PlayGame();

                     _diceGame.OnWin -= onWin;
                     _diceGame.OnLoose -= onLoose;
                     _diceGame.OnDraw -= onDraw;

                     if (playerWon)
                     {
                        ApplyPlayerBankRulesAfterWin();
                     }
                     ApplyBarRuleIfOverMax();

                     SaveGame();

                     break;
                  case 3:
                     SaveGame();

                     Console.WriteLine("Good Luck!");

                     return;
                  default:
                     Console.WriteLine("Wrong input! Try from 1 to 3!");
                     break;
               }
            }
            else
            {
               Console.WriteLine("Wrong input! Try from 1 to 3!");
            }
         } 
      }

      private void FirstSteps()
      {
         Console.WriteLine("Welcome to our Casino777!");

         while (true)
         {
            Console.WriteLine("\t1 - Create Profile");
            Console.WriteLine("\t2 - Load Profile\n");
            Console.Write("Your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice < 3)
            {
               SetName();

               bool isLoaded = false;

               if (choice == 2)
               {
                  string data = _fileSystem.LoadData("profile");

                  string[] lines = data.Split('\n');


                  foreach (string line in lines)
                  {
                     string[] parts = line.Split(' ');

                     if (_player.Name == parts[0])
                     {
                        if (int.TryParse(parts[1], out int result))
                        {
                           _player.Balance = (uint) result;
                        }
                        else
                        {
                           _player.Balance = 10000;
                        }

                        Console.WriteLine($"Welcome back, {_player.Name}! Your balance = {_player.Balance}$");
                        isLoaded = true;
                        break;
                     }
                  }

                  if (!isLoaded)
                  {
                     Console.WriteLine("We can't find your profile. It will be created!");
                     _fileSystem.SaveData(_player.ToString() ?? string.Empty, "profile");
                  }
               }

               if (choice == 1 || !isLoaded)
               {
                  Console.WriteLine($"\n{_player.Name}, your profile successfully created!");
                  _fileSystem.SaveData(_player.ToString() ?? string.Empty, "profile");
               }

               return;
            }
            else
            {
               Console.WriteLine("\nWrong input! Try only 1 or 2!\n");
            }
         }
      }

      private void SetName()
      {
         Console.Write("Input your name: ");

         string name = Console.ReadLine() ?? "Player";

         _player = new Player(name, 10000);

         return;
      }

      private void SaveGame()
      {
         string data = _fileSystem.LoadData("profile");

         string[] lines = data.Split('\n');

         for (int i = 0; i < lines.Length; i++)
         {
            string[] parts = lines[i].Split(' ');

            if (_player.Name == parts[0])
            {
               lines[i] = _player.ToString() ?? "";
            }
         }

         string updatedData = string.Join("\n", lines);

         _fileSystem.SaveProfile(updatedData, "profile");
      }

      private int PlaceBet()
      {
         while (true)
         {
            Console.Write("Place a bet: ");

            if (!int.TryParse(Console.ReadLine(), out int bet))
            {
               Console.WriteLine("Invalid sum. Try again!");
               continue;
            }
            if (bet <= 0)
            {
               Console.WriteLine("Bet must be positive. Try again!");
               continue;
            }
            if (bet > _player.Balance)
            {
               Console.WriteLine($"Too much. Max is {_player.Balance}. Try again!");
               continue;
            }
            return bet;
         }
      }

      private void ApplyPlayerBankRulesAfterWin()
      {
         if (_player.Balance <= MaxPlayerBank)
         {
            return;
         }
         uint overflow = _player.Balance - MaxPlayerBank;
         _player.Balance = MaxPlayerBank;
         Console.WriteLine($"You ruined the casino! Overflow: {overflow}$. A new casino will be built.");
      }
      private void ApplyBarRuleIfOverMax()
      {
         if (_player.Balance <= MaxPlayerBank)
         {
            return;
         }
         _player.Balance /= 2;
         Console.WriteLine("You wasted half of your bank money in casino's bar");
      }
   }
}
