using System;

namespace calculator_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; ) {
                string operation, value1, value2;
                double number1 = 0, number2 = 0;
                Console.WriteLine("Please choose one operation");
                Console.WriteLine("1:+  2:-  3:×  4:÷");
                operation = Console.ReadLine();
                Console.WriteLine("Please enter the first number");
                value1 = Console.ReadLine();
                Console.WriteLine("Please enter the second number");
                value2 = Console.ReadLine();
                double.TryParse(value1, out number1);
                double.TryParse(value2, out number2);

                if (operation == "1")
                    Console.WriteLine($"The result is :{number1 + number2}");
                if (operation == "2")
                    Console.WriteLine($"The result is :{number1 - number2}");
                if (operation == "3")
                    Console.WriteLine($"The result is :{number1 * number2}");
                if (operation == "4")
                    Console.WriteLine($"The result is :{number1 / number2}");

                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
