using LosevD_GUN39_GUNPC.Errors;

namespace LosevD_GUN39_GUNPC.Dices
{
   public struct Dice
   {
      private int _min;

      private int _max;

      public int Number { get => Random.Shared.Next(_min, _max + 1); }

      public Dice(int min, int max)
      {
         if (min < 1 || min >= int.MaxValue)
         {
            throw new WrongDiceNumberException($"Invalid minimum value: {min}. Valid: 1 to {int.MaxValue}");
         }
         if (max < 1 || max >= int.MaxValue)
         {
            throw new WrongDiceNumberException($"Invalid maximum value: {max}. Valid: 1 to {int.MaxValue}");
         }
         if (min > max)
         {
            throw new WrongDiceNumberException($"Maximum value {max} must be more than minimum {min}");
         }
         _min = min;
         _max = max;
      }
   }
}
