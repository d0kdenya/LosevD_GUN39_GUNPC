using LosevD_GUN39_GUNPC.Game;

namespace LosevD_GUN39_GUNPC
{
   internal class Program
   {
      static void Main(string[] args)
      {
         DiceGame diceGame = new DiceGame(10, 1, 6);

         diceGame.OnWin += () => Console.WriteLine("Win!");
         diceGame.OnLoose += () => Console.WriteLine("Lose!");
         diceGame.OnDraw += () => Console.WriteLine("Draw!");

         diceGame.PlayGame();
      }
   }
}
