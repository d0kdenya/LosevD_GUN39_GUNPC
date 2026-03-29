using System.Text;


class Program
{
   static void Main(string[] args)
   {
      // Массивы для заданий А
      int[] fibonacci = new int[8];
      string[] months =
      {
         "January", "February", "March", "April",
         "May", "June", "July", "August",
         "September", "October", "November", "December"
      };
      int[][] matrix = { new int[3], new int[3], new int[3] };
      double[][] jagged = { new double[5], new double[2], new double[4] };

      // Массивы для заданий B
      int[] array1 = { 1, 2, 3, 4, 5, 6 };
      int[] array2 = new int[3];
      int[] small = { 1, 2, 3, 4, 5 };

      // Задание 1:
      fibonacci[0] = 0;
      fibonacci[1] = 1;
      fibonacci[2] = fibonacci[0] + fibonacci[1];
      fibonacci[3] = fibonacci[1] + fibonacci[2];
      fibonacci[4] = fibonacci[2] + fibonacci[3];
      fibonacci[5] = fibonacci[3] + fibonacci[4];
      fibonacci[6] = fibonacci[4] + fibonacci[5];
      fibonacci[7] = fibonacci[5] + fibonacci[6];

      Console.WriteLine("Task 1 Result: ");
      Console.WriteLine(fibonacci[0]);
      Console.WriteLine(fibonacci[1]);
      Console.WriteLine(fibonacci[2]);
      Console.WriteLine(fibonacci[3]);
      Console.WriteLine(fibonacci[4]);
      Console.WriteLine(fibonacci[5]);
      Console.WriteLine(fibonacci[6]);
      Console.WriteLine(fibonacci[7]);
      Console.WriteLine("\n==================\n");

      // Задание 2
      Console.WriteLine("Task 2 Result: ");
      Console.WriteLine(months[0]);
      Console.WriteLine(months[1]);
      Console.WriteLine(months[2]);
      Console.WriteLine(months[3]);
      Console.WriteLine(months[4]);
      Console.WriteLine(months[5]);
      Console.WriteLine(months[6]);
      Console.WriteLine(months[7]);
      Console.WriteLine(months[8]);
      Console.WriteLine(months[9]);
      Console.WriteLine(months[10]);
      Console.WriteLine(months[11]);
      Console.WriteLine("\n==================\n");

      // Задание 3
      matrix[0][0] = 2;
      matrix[0][1] = 3;
      matrix[0][2] = 4;
      matrix[1][0] = matrix[0][0] * 2;
      matrix[1][1] = matrix[0][1] * 3;
      matrix[1][2] = matrix[0][2] * 4;
      matrix[2][0] = matrix[1][0] * 2;
      matrix[2][1] = matrix[1][1] * 3;
      matrix[2][2] = matrix[1][2] * 4;

      Console.WriteLine("Task 3 Result: ");
      Console.Write("| " + matrix[0][0]);
      Console.Write(" | " + matrix[0][1]);
      Console.Write(" | " + matrix[0][2] + " |");
      Console.WriteLine();
      Console.Write("| " + matrix[1][0]);
      Console.Write(" | " + matrix[1][1]);
      Console.Write(" | " + matrix[1][2] + " |");
      Console.WriteLine();
      Console.Write("| " + matrix[2][0]);
      Console.Write(" | " + matrix[2][1]);
      Console.Write(" | " + matrix[2][2] + " |");
      Console.WriteLine();
      Console.WriteLine("\n==================\n");

      // Задание 4
      jagged[0][0] = 1;
      jagged[0][1] = 2;
      jagged[0][2] = 3;
      jagged[0][3] = 4;
      jagged[0][4] = 5;

      jagged[1][0] = Math.E;
      jagged[1][1] = Math.PI;

      jagged[2][0] = Math.Log10(1);
      jagged[2][1] = Math.Log10(10);
      jagged[2][2] = Math.Log10(100);
      jagged[2][3] = Math.Log10(1000);

      Console.WriteLine("Task 4 Result: ");
      Console.Write("| " + jagged[0][0]);
      Console.Write(" | " + jagged[0][1]);
      Console.Write(" | " + jagged[0][2]);
      Console.Write(" | " + jagged[0][3]);
      Console.Write(" | " + jagged[0][4] + " |");
      Console.WriteLine();
      Console.Write("| " + jagged[1][0]);
      Console.Write(" | " + jagged[1][1] + " |");
      Console.WriteLine();
      Console.Write("| " + jagged[2][0]);
      Console.Write(" | " + jagged[2][1]);
      Console.Write(" | " + jagged[2][2]);
      Console.Write(" | " + jagged[2][3] + " |");
      Console.WriteLine();
      Console.WriteLine("\n==================\n");

      // Задание 5
      Array.Copy(array1, array2, 3);
   
      Console.WriteLine("Task 5 Result: ");
      Console.WriteLine(array2[0]);
      Console.WriteLine(array2[1]);
      Console.WriteLine(array2[2]);
      Console.WriteLine("\n==================\n");

      // Задание 6
      Array.Resize(ref small, small.Length * 2);

      Console.WriteLine("Task 6 Result: ");
      Console.WriteLine(small[0]);
      Console.WriteLine(small[1]);
      Console.WriteLine(small[2]);
      Console.WriteLine(small[3]);
      Console.WriteLine(small[4]);
      Console.WriteLine(small[5]);
      Console.WriteLine(small[6]);
      Console.WriteLine(small[7]);
      Console.WriteLine(small[8]);
      Console.WriteLine(small[9]);
      Console.WriteLine("\n==================\n");
   }
}