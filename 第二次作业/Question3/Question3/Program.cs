using System;

namespace Question3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            Console.WriteLine("请输入一个正整数");
            int.TryParse(Console.ReadLine(), out a);
            Program.sieve(a);
        }

        static void sieve(int number)
        {
            //int[] numberArray = new int[number-1];
            //for(int i = 2; i <= number; i++)
                //numberArray[i - 2] = i;
            string array = "";
            for(int k = 2; k < number+1; k++)
            {
                bool isPrimeNumber = true;
                for(int i = 2; i * i<= k; i++)
                { if (k % i == 0) isPrimeNumber = false; }
                if (isPrimeNumber == true) { array = array + k + " "; }
             }

            Console.WriteLine("素数有：");
                Console.WriteLine(array);
        }
    }
}