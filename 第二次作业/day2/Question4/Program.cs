using System;

namespace Question4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[, ] array = { {1,2,3,4}, {5,1,2,3}, {9,5,1,2} };

            if (isToeplitzArray(array) == true)
                Console.WriteLine("这是一个托普利兹矩阵");
            else
                Console.WriteLine("这不是一个托普利兹矩阵");
            
        }
        static bool isToeplitzArray(int [,] array)
        {
            bool isTrue = true;
            int row = array.GetLength(0);
            int column = array.GetLength(1);

            //检查主对角线以下
            for(int i = 0; i < row; i++)
            {
                int k = i;
                for(int j =0; j+1 < column && k+1 < row; j++,k++)
                if (array[k,j] != array[k + 1, j + 1])
                    isTrue = false;
                    }

            //检查主对角线以上
            for (int j = 1; j < column; j++)
            {
                int k = j;
                for (int i = 0; i + 1 < row && k + 1 < column; i++, k++)
                    if (array[i, k] != array[i + 1, k + 1])
                        isTrue = false;
            }
            return isTrue;
        }
    }
}
