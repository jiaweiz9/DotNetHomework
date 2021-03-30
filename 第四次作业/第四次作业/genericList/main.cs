using System;

namespace genericList
{
    class main
    {
        static void Main(string[] args)
        {
            GenericList<int> genericList = new GenericList<int>();
            for(int i =1; i<10; i++)
            {
                genericList.Add(i);
            }
            int sum=0,max=0,min = 100;
            genericList.ForEach(m => {
                sum += m; if (m > max) max = m;if (m < min) min = m;
                });
            Console.WriteLine("sum:" + sum + " max:" + max + " min:" + min);
        }
    }
}
