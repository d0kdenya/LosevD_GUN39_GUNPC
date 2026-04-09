using LosevD_GUN39_GUNPC.Combat;
using LosevD_GUN39_GUNPC.Dungeon;
using LosevD_GUN39_GUNPC.Units;
using LosevD_GUN39_GUNPC.Utils;

namespace LosevD_GUN39_GUNPC.Game
{
   public sealed class GameLoop
   {
      private bool _quitGame;

      private Unit _player;

      private DungeonRoom _dungeon;

      private DungeonRoom _currentRoom;

      private CommandParser _parser = new CommandParser();

      private readonly CombatManager _combatManager = new CombatManager();

      public void StartGame()
      {
         Initialize();
         Console.WriteLine("Entering the dungeon...\n");
         StartGameLoop();
      }

      #region Game Loop;

      private void Initialize()
      {
         Console.WriteLine("Welcome, player!");
         _dungeon = DungeonBuilder.BuildDungeon();
         Console.Write("Enter your name: ");
         _player = UnitFactoryDemo.CreatePlayer(Console.ReadLine());
         Console.WriteLine($"Hello {_player.Name}\n");

         _currentRoom = _dungeon;
      }

      private void StartGameLoop()
      {
         while (!_currentRoom.IsFinal && !_quitGame)
         {
            StartRoomEncounter(_currentRoom, out var success);
            if (!success)
            {
               return;
            }
            while (true)
            {
               DisplayRouteOptions(_currentRoom);

               var line = Console.ReadLine() ?? "";

               if (_parser.TryDispatch(line, out CommandResult commandResult, out string args))
               {
                  switch (commandResult)
                  {
                     case CommandResult.Info:
                        GameCommands.PrintPlayerInfo(_player);
                        break;
                     case CommandResult.Inventory:
                        if (int.TryParse(args, out int index))
                        {
                           GameCommands.PrintPlayerInventory(_player, index);
                        }
                        else
                        {
                           GameCommands.PrintPlayerInventory(_player, -1);
                        }
                        break;
                     case CommandResult.Go:
                        if (!GameCommands.TryGoNextRoom(ref _currentRoom, args))
                        {
                           continue;
                        }
                        break;
                     case CommandResult.Quit:
                        GameCommands.PrintGameOver(_player);
                        _quitGame = true;
                        return;
                     default:
                        Console.WriteLine("\nUnknown command!\n");
                        break;
                  }
               }
               else
               {
                  if (GameCommands.TryGoNextRoom(ref _currentRoom, line))
                  {
                     break;
                  }
               }
            }
         }

         if (_quitGame)
         {
            return;
         }

         Console.WriteLine($"Congratulations, {_player.Name}");
         Console.WriteLine("Result: ");
         Console.WriteLine(_player.ToString());
      }

      private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
      {
         success = true;
         if (currentRoom.Loot != null)
         {
            _player.AddItemToInventory(currentRoom.Loot);
         }
         if (currentRoom.Enemy != null)
         {
            CombatResult result = _combatManager.StartCombat(_player, currentRoom.Enemy, _parser, out string direction);

            if (result == CombatResult.PlayerWon)
            {
               _player.HandleCombatComplete();
               LootEnemy(currentRoom.Enemy);
            }
            else if (result == CombatResult.Escaped)
            {
               GameCommands.TryGoNextRoom(ref _currentRoom, direction);
            }
            else if (result == CombatResult.QuitGame)
            {
               GameCommands.PrintGameOver(_player);
               _quitGame = true;
               success = false;
            }
            else
            {
               success = false;
            }
         }

         void LootEnemy(Unit enemy)
         {
            _player.AddItemsFromUnitToInventory(enemy);
         }
      }

      private void DisplayRouteOptions(DungeonRoom currentRoom)
      {
         Console.WriteLine("\nWhere to go?");

         foreach (var room in currentRoom.Rooms)
         {
            Console.Write($"{room.Key} - {(int)room.Key}\t");
         }
         Console.Write(" Your choice: ");
      }

      #endregion
   }
}
