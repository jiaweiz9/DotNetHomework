using System;

namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            double []array = {1,2,3,4,5,6 };
            Console.WriteLine("max={0},min={1},sum={2},average={3}", 
                maxArray(array),minArray(array),sumArray(array),averageArray(array));

        }
        static double maxArray(double[] array)
        {
            double max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
            }
            return max;
        }

        static double minArray(double[] array)
        {
            double min = array[0] ;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
            }
            return min;
        }

        static double sumArray(double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }

        static double averageArray(double[] array)
        {
            return sumArray(array) / array.Length;
        }
    }
}
