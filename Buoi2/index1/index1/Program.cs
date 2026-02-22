using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace index1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();


            ////create an array of int about 4 elememnts
            //Array a = Array.CreateInstance(typeof(int), 4);

            //for (int i = 0; i < a.GetLength(0); i++)
            //{
            //    //set value rnd.Next(0,10) in position i
            //    a.SetValue(rnd.Next(0, 10), i);
            //}
            //foreach (int x in a)
            //{
            //    Console.WriteLine(x);

            //}
            //int sum = 0;
            //for (int i = 0; i < a.GetLength(0); i++)
            //{
            //    //get value in position i (return an object)
            //    sum = sum + (int)a.GetValue(i);
            //}
            //Console.WriteLine(sum);

            Array arr2 = Array.CreateInstance(typeof(int), new int[] {3, 4}, new int[] {0,1});
            for (int i  = arr2.GetLowerBound(0); i <= arr2.GetUpperBound(0); i++)
            {
                for (int j = arr2.GetLowerBound(1); j <= arr2.GetUpperBound(1); j++)
                {
                    arr2.SetValue(1, i,j);
                    
                }
            }
            for (int i = arr2.GetLowerBound(0); i <= arr2.GetUpperBound(0); i++)
            {
                for (int j = arr2.GetLowerBound(1); j <= arr2.GetUpperBound(1); j++)
                {
                    Console.Write($"a({i},{j}) = {(int)arr2.GetValue(i, j)}  ");

                }
                Console.WriteLine();
            }
            //Console.WriteLine(sum);
            //Console.WriteLine($"1 from {arr2.GetLowerBound(0)} to {arr2.GetUpperBound(0)}");
            //Console.WriteLine($"2 from {arr2.GetLowerBound(1)} to {arr2.GetUpperBound(1)}");
        }
    }
}
