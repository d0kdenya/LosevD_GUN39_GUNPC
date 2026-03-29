class Program
{
   static void Main(string[] args)
   {
      // Задание 1

      int[] fibonacci = new int[10];

      for (int i = 0; i < fibonacci.Length; i++)
      {
         if (i == 0)
         {
            fibonacci[i] = 0;
         }
         else if (i == 1)
         {
            fibonacci[i] = 1;
         }
         else
         {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
         }
      }

      Console.WriteLine("Task 1 result: ");

      for (int i = 0; i < fibonacci.Length; i++)
      {
         Console.WriteLine(fibonacci[i]);
      }
      Console.WriteLine("\n=================\n");


      // Задание 2
      Console.WriteLine("Task 2 result: ");

      for (int i = 2; i <= 20; i++)
      {
         if (i % 2 == 0)
         {
            Console.WriteLine(i);
         }
      }
      Console.WriteLine("\n=================\n");


      // Задание 3
      for (int i = 0; i <= 5; i++)
      {
         for (int j = 0; j <= 5; j++)
         {
            if (i == 0 && j > 0) 
            {
               if (i == 0 && j == 1)
               {
                  Console.Write(" ");
               }
               Console.Write("{0,4}", j);
            }
            else if (i > 0 && j == 0)
            {
               Console.Write(i);
            }
            else if (i > 0 && j > 0)
            {
               Console.Write("{0,4}", i * j);
            }
         }
         Console.WriteLine();
      }
      Console.WriteLine("\n=================\n");


      // Задание 4

      string password = "qwerty";
      string attempt;

      do
      {
         Console.Write("Input password: ");
         attempt = Console.ReadLine();

         if (attempt != password)
         {
            Console.WriteLine("Incorrect!\n");
         }
      } while (attempt != password);

      Console.WriteLine("Correct!");
      Console.WriteLine("\n=================\n");
   }
}