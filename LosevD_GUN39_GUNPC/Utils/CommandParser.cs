namespace LosevD_GUN39_GUNPC.Utils
{
   public class CommandParser
   {
      public bool TryParseCommand(string line, out string command, out string args)
      {
         command = "";
         args = "";

         line = line?.Trim() ?? "";

         if (line.Length == 0 || line[0] != '-')
         {
            return false;
         }

         string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

         command = parts[0];

         args = parts.Length > 1
            ? string.Join(" ", parts.Skip(1))
            : "";

         return true;
      }

      public bool TryDispatch(string line, out CommandResult commandResult, out string args)
      {
         bool isParse = TryParseCommand(line, out string command, out args);

         if (!isParse)
         {
            commandResult = CommandResult.ErrorCommand;
         }
         else
         {
            switch (command)
            {
               case "-info":
                  commandResult = CommandResult.Info;
                  break;
               case "-inventory":
                  commandResult = CommandResult.Inventory;
                  break;
               case "-go":
                  commandResult = CommandResult.Go;
                  break;
               case "-quit":
                  commandResult = CommandResult.Quit;
                  break;
               default:
                  commandResult = CommandResult.ErrorCommand;
                  break;
            }
         }

         return isParse;
      }
   }
}
