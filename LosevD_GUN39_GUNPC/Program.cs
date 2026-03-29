class Program
{
   static void Main(string[] args)
   {
      Console.Write("Input first value: ");

      if (!Int32.TryParse(Console.ReadLine(), out int a))
      {
         Console.WriteLine("Not a number!");
         return;
      }

      Console.Write("Input second value: ");

      if (!Int32.TryParse(Console.ReadLine(), out int b))
      {
         Console.WriteLine("Not a number!");
         return;
      }

      Console.Write("Input operation (+, -, *, /, %, &, |, ^): ");
      var s = Console.ReadLine();

      if (s.Length != 1)
      {
         Console.WriteLine("Wrong operation!");
         return;
      }

      switch (s[0])
      {
         case '+':
            Console.WriteLine("Binary result of {0} + {1} = {2}", a, b, Convert.ToString(a + b, 2));
            Console.WriteLine("Decimal result of {0} + {1} = {2}", a, b, Convert.ToString(a + b, 10));
            Console.WriteLine("Hexadecimal result of {0} + {1} = {2}", a, Convert.ToString(a + b, 16));
            break;
         case '-':
            Console.WriteLine("Binary result of {0} - {1} = {2}", a, b, Convert.ToString(a - b, 2));
            Console.WriteLine("Decimal result of {0} - {1} = {2}", a, b, Convert.ToString(a - b, 10));
            Console.WriteLine("Hexadecimal result of {0} - {1} = {2}", a, b, Convert.ToString(a - b, 16));
            break;
         case '*':
            Console.WriteLine("Binary result of {0} * {1} = {2}", a, b, Convert.ToString(a * b, 2));
            Console.WriteLine("Decimal result of {0} * {1} = {2}", a, b, Convert.ToString(a * b, 10));
            Console.WriteLine("Hexadecimal result of {0} * {1} = {2}", a, b, Convert.ToString(a * b, 16));
            break;
         case '/':
            Console.WriteLine("Binary result of {0} / {1} = {2}", a, b, Convert.ToString(a / b, 2));
            Console.WriteLine("Decimal result of {0} / {1} = {2}", a, b, Convert.ToString(a / b, 10));
            Console.WriteLine("Hexadecimal result of {0} / {1} = {2}", a, b, Convert.ToString(a / b, 16));
            break;
         case '%':
            Console.WriteLine("Binary result of {0} % {1} = {2}", a, b, Convert.ToString(a % b, 2));
            Console.WriteLine("Decimal result of {0} % {1} = {2}", a, b, Convert.ToString(a % b, 10));
            Console.WriteLine("Hexadecimal result of {0} % {1} = {2}", a, b, Convert.ToString(a % b, 16));
            break;
         case '&':
            Console.WriteLine("Binary result of {0} & {1} = {2}", a, b, Convert.ToString(a & b, 2));
            Console.WriteLine("Decimal result of {0} & {1} = {2}", a, b, Convert.ToString(a & b, 10));
            Console.WriteLine("Hexadecimal result of {0} & {1} = {2}", a, b, Convert.ToString(a & b, 16));
            break;
         case '|':
            Console.WriteLine("Binary result of {0} | {1} = {2}", a, b, Convert.ToString(a | b, 2));
            Console.WriteLine("Decimal result of {0} | {1} = {2}", a, b, Convert.ToString(a | b, 10));
            Console.WriteLine("Hexadecimal result of {0} | {1} = {2}", a, b, Convert.ToString(a | b, 16));
            break;
         case '^':
            Console.WriteLine("Binary result of {0} ^ {1} = {2}", a, b, Convert.ToString(a ^ b, 2));
            Console.WriteLine("Decimal result of {0} ^ {1} = {2}", a, b, Convert.ToString(a ^ b, 10));
            Console.WriteLine("Hexadecimal result of {0} ^ {1} = {2}", a, b, Convert.ToString(a ^ b, 16));
            break;
         default:
            Console.WriteLine("Wrong sing!");
            return;
      }
   }
}