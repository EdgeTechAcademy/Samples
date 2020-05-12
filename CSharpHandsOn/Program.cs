using System;
using System.Linq;

namespace CSharpHandsOn
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array1 = { 1, 4, 6, 1, 3, 9, 0, -1, -6, 11 };
            //int[] array2 = { -9, -7 - 7, -11, -7, -88, -5, -10 };
            //double ave;

            //ave = FindAverage(array1);
            //Console.WriteLine("The average of array1 is : " + ave);

            //ave = FindAverage(array2);
            //Console.WriteLine("The average of array2 is : " + ave);
            Console.Write("Enter a #: ");
            string str = Console.ReadLine();
            int x;
            Int32.TryParse(str, out x);
            MultiplicationTable(x);
        }
        /*
               | 0  1  2  3  4  5
            ---|------------------
             0 | 0  0  0  0  0  0
             1 | 0  1  2  3  4  5
             2 | 0  2  4  6  8 10
             3 | 0  3  6  9 12 15
             4 | 0  4  8 12 16 20
             5 | 0  5 10 15 20 25
        */

        static void MultiplicationTable(int num)
        {
            Console.Write("   |");
            for (int i = 0; i <= num; i++)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();
            Console.Write("---+");
            for (int i = 0; i <= num; i++)
            {
                Console.Write($"---");
            }
            Console.WriteLine();

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {

                }
            }
        }

        static double FindAverage(int[] arNums)
        {
            double average, total = 0; ;

            for (int i = 0; i < arNums.Length; i++)
            {
                total += arNums[i];
            }

            total = 0;
            foreach (int num in arNums)
            {
                total += num;
            }

            average = arNums.Sum()/arNums.Length;

            average = arNums.Average();

            average = total / arNums.Length;
            return average;
        }
    }
}
