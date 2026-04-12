using LosevD_GUN39_GUNPC.Dices;

namespace LosevD_GUN39_GUNPC.Game
{
   public class DiceGame : CasinoGameBase
   {
      private int _min;

      private int _max;

      private int _diceCount;

      private List<Dice> _dices = new List<Dice>();

      public DiceGame(int diceCount, int min, int max)
      {
         if (diceCount < 1)
         {
            throw new ArgumentOutOfRangeException($"Invalid diceCount: {diceCount}. Valid: 1 to {int.MaxValue}!");
         }

         _diceCount = diceCount;
         _min = min;
         _max = max;

         FactoryMethod();
      }

      public override void PlayGame()
      {
         int playerScore = 0;

         int computerScore = 0;

         foreach (Dice dice in _dices)
         {
            playerScore += dice.Number;
         }
         foreach (Dice dice in _dices)
         {
            computerScore += dice.Number;
         }

         Console.WriteLine("Final score: ");
         Console.WriteLine($"Player - {playerScore} : Computer - {computerScore}");

         CheckResult(playerScore, computerScore);
      }

      protected override void FactoryMethod()
      {
         _dices.Clear();

         for (int i = 0; i < _diceCount; i++)
         {
            _dices.Add(new Dice(_min, _max));
         }
      }

      private void CheckResult(int playerScore, int computerScore)
      {
         if (playerScore > computerScore)
         {
            OnWinInvoke();
         }
         else if (playerScore < computerScore)
         {
            OnLooseInvoke();
         }
         else
         {
            OnDrawInvoke();
         }
      }
   }
}
