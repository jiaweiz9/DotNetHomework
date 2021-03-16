using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            for (; ; )
            {
                Console.WriteLine("请输入一个正整数");
                number = int.Parse(Console.ReadLine());
                double sqrtNumber = Math.Sqrt(number);
                Console.WriteLine("该数字的素数因子有：");
                for (int i = 2; i <= number; i++)
                {
                    int j = 0;
                    for (; number % i == 0; j++)
                    {
                        number = number / i;
                    }
                    if (j != 0)
                    {
                        Console.Write(i);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
