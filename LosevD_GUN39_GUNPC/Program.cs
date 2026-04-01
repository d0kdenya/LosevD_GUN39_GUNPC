namespace LosevD_GUN39_GUNPC
{
   internal class Program
   {
      // Задание 1
      private class ListTask
      {
         private readonly List<string> _lines;

         public ListTask()
         {
            _lines = new List<string>() { "First line", "Second line", "Third line" };
         }

         public void TaskLoop()
         {
            string answer = "";

            do
            {
               Console.Write("Input next line: ");

               string inputLine = Console.ReadLine();

               if (string.IsNullOrWhiteSpace(inputLine))
               {
                  Console.WriteLine("Incorrect input!");

                  continue;
               }

               _lines.Add(inputLine);

               PrintLines();

               Console.Write("Input one more line: ");

               inputLine = Console.ReadLine();

               if (string.IsNullOrWhiteSpace(inputLine))
               {
                  Console.WriteLine("Incorrect input!");

                  continue;
               }

               _lines.Insert(_lines.Count / 2, inputLine);

               PrintLines();

               Console.Write("Input 'exit' to close the program, another input to continue: ");

               answer = Console.ReadLine();
            }
            while (answer != "exit");
         }

         private void PrintLines()
         {
            foreach (string line in _lines)
            {
               Console.WriteLine(line);
            }
            Console.WriteLine();
         }
      }

      // Задание 2
      private class Journal
      {
         private readonly Dictionary<string, List<int>> _journal = new Dictionary<string, List<int>>();

         public void TaskLoop()
         {
            string answer = "";

            do
            {
               Console.Write("Input student's name: ");

               string name = Console.ReadLine();

               if (string.IsNullOrWhiteSpace(name))
               {
                  Console.WriteLine("Incorrect input!");

                  continue;
               }

               int mark;

               do
               {
                  Console.Write("Input {0} mark: ", name);

                  if (int.TryParse(Console.ReadLine(), out mark))
                  {
                     if (mark > 5 || mark < 2)
                     {
                        Console.WriteLine("Mark must be between 2 and 5!");
                     }
                  }
                  else
                  {
                     Console.WriteLine("Mark must be int!");
                  }
               }
               while (mark > 5 || mark < 2);
               

               if (_journal.TryGetValue(name, out List<int> list))
               {
                  list.Add(mark);
               }
               else
               {
                  list = new List<int>() { mark };

                  _journal.Add(name, list);
               }

               Console.Write("Input student's name to check his mark: ");

               name = Console.ReadLine();

               if (!_journal.ContainsKey(name))
               {
                  Console.WriteLine("Student does not exist!");
               }
               else
               {
                  float avgMark = CalculateStudentMark(name);

                  Console.WriteLine("Student {0} has avg {1}", name, avgMark);
               }

               Console.Write("Input 'exit' to close the program, another input to continue: ");

               answer = Console.ReadLine();
            }
            while (answer != "exit");
         }

         private float CalculateStudentMark(string name)
         {
            int sum = 0;
            int count = 0;

            List<int> marks = _journal[name];

            foreach (int mark in marks)
            {
               sum += mark;
               count++;
            }

            return (float) sum / count;
         }
      }

      // Задание 3
      private class DoubleLinkedList
      {
         private class Node
         {
            public int Value;
            public Node Next;
            public Node Prev;

            public Node(int value)
            {
               Value = value;
            }
         }

         private Node _head;
         private Node _tail;

         public void TaskLoop()
         {
            int count;

            string answer = "";

            do
            {
               _head = null;
               _tail = null;

               do
               {
                  Console.Write("Input count values (between 3 and 6): ");
                  int.TryParse(Console.ReadLine(), out count);
               }
               while (count < 3 || count > 6);

               for (int i = 0; i < count; i++)
               {
                  Console.Write("Input value: ");

                  if (int.TryParse(Console.ReadLine(), out int value))
                  {
                     if (i == 0)
                     {
                        _head = new Node(value);
                        _tail = _head;
                     }
                     else if (i == 1)
                     {
                        _tail = new Node(value);
                        _head.Next = _tail;
                        _tail.Prev = _head;
                     }
                     else
                     {
                        Node tmp = _tail;
                        Node tail = new Node(value);
                        tmp.Next = tail;
                        tail.Prev = tmp;
                        _tail = tail;
                     }
                  }
                  else
                  {
                     Console.WriteLine("Incorrect value!");

                     i--;
                  }
               }

               Console.WriteLine("Print: ");

               PrintValues();

               Console.WriteLine("Reverse Print: ");

               PrintReverseValues();

               Console.Write("Input 'exit' to close the program, another input to continue: ");

               answer = Console.ReadLine();
            }
            while (answer != "exit");
         }

         private void PrintValues()
         {
            Node next = _head;

            while (next != null)
            {
               Console.WriteLine(next.Value);
               next = next.Next;
            }
            Console.WriteLine();
         }

         private void PrintReverseValues()
         {
            Node prev = _tail;

            while (prev != null)
            {
               Console.WriteLine(prev.Value);
               prev = prev.Prev;
            }
            Console.WriteLine();
         }
      }

      static void Main(string[] args)
      {
         Console.Write("Enter 1, 2 or 3 to check task 1, 2 or 3: ");

         int.TryParse(Console.ReadLine(), out int task);

         switch (task)
         {
            case 1:
               CheckTaskFirst();
               break;
            case 2:
               CheckTaskSecond();
               break;
            case 3:
               CheckTaskThird();
               break;
            default:
               Console.WriteLine("Incorrect task!");
               break;
         }
      }

      private static void CheckTaskFirst()
      {
         ListTask listTask = new ListTask();
         listTask.TaskLoop();
      }

      private static void CheckTaskSecond()
      {
         Journal journal = new Journal();
         journal.TaskLoop();
      }

      private static void CheckTaskThird()
      {
         DoubleLinkedList doubleLinkedList = new DoubleLinkedList();
         doubleLinkedList.TaskLoop();
      }
   }
}
