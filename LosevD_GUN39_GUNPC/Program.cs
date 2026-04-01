using System.Text;

namespace LosevD_GUN39_GUNPC
{
   internal class Program
   {
      static string ConcatenateStrings(string str1, string str2)
      {
         return str1 + str2;
      }

      static string GreetUser(string name, int age)
      {
         return $"Hello, {name}!\n" +
            $"You are {age} years old.";
      }

      static string GetStringInfo(string str)
      {
         return $"String length: {str.Length},\n" +
            $"String Upper Case: {str.ToUpper()},\n" +
            $"String Lower Case: {str.ToLower()}";
      }

      static string GetFirstFiveSymbols(string str)
      {
         if (str.Length < 5)
         {
            Console.WriteLine("String must be longer than 5 symbols!");

            return "";
         }

         return str.Substring(0, 5);
      }

      static StringBuilder ConvertArrayToString(string[] strings)
      {
         StringBuilder builder = new StringBuilder();

         for (int i = 0; i < strings.Length; i++)
         {
            if (i < strings.Length - 1)
            {
               builder.Append(strings[i]);
               builder.Append(" ");
            }
            else
            {
               builder.Append(strings[i]);
            }
         }

         return builder;
      }

      static string ReplaceWords(string str, string search, string replace)
      {
         return str.Replace(search, replace);
      }

      static void Main(string[] args)
      {
         string str1 = "Hello ";
         string str2 = "World";

         Console.WriteLine("======================\n");
         Console.WriteLine($"Task1: {ConcatenateStrings(str1, str2)}");
         Console.WriteLine("\n======================\n");

         Console.WriteLine($"Task2: {GreetUser("Dan", 24)}");
         Console.WriteLine("\n======================\n");

         Console.WriteLine($"Task3: {GetStringInfo("Backend Developer")}");
         Console.WriteLine("\n======================\n");

         Console.WriteLine($"Task4: {GetFirstFiveSymbols("ABCDEFGHIJKLMNOPQRSTUVWXYZ")}");
         Console.WriteLine("\n======================\n");

         string[] strings = { "Line 1", "Line 2", "Line 3", "Line 4", "Line 5" };

         Console.WriteLine($"Task5: {ConvertArrayToString(strings).ToString()}");
         Console.WriteLine("\n======================\n");

         Console.WriteLine($"Task6: {ReplaceWords("How are you?", "you", "you doing")}");
         Console.WriteLine("\n======================\n");
      }
   }
}
