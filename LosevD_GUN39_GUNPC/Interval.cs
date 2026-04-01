namespace LosevD_GUN39_GUNPC
{
   internal struct Interval
   {
      private Random _random;

      public int Min { get; }
      public int Max { get; }
      public int Get { get => _random.Next(Min, Max + 1); }

      public Interval(int minValue, int maxValue)
      {
         _random = new Random();

         if (minValue < 0)
         {
            minValue = 0;

            Console.WriteLine("Форсированная установка минимального значения! minValue должно быть >= 0!");
         }

         if (maxValue < 0)
         {
            maxValue = 0;

            Console.WriteLine("Форсированная установка максимального значения! maxValue должно быть >= 0!");
         }

         if (minValue > maxValue)
         {
            int tmp = minValue;
            minValue = maxValue;
            maxValue = tmp;

            Console.WriteLine("Некорректные входные данные! minValue не должно быть больше maxValue!");
         }

         if (minValue == maxValue)
         {
            maxValue += 10;

            Console.WriteLine("Некорректные входные данные! minValue не должно быть равно maxValue, maxValue был увеличен на 10!");
         }

         Min = minValue;
         Max = maxValue;
      }
   }
}
