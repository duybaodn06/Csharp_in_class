using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RecurSearch2
{
    internal class Program
    {
        static int RecuSearch2(Array arr, int value, int from = 0)
        {
            if (from >= arr.GetLength(0)) return -1;

            if ((int)arr.GetValue(from) == value) return from;

            return RecuSearch2(arr, value, from + 1);
        }

        static void Main(string[] args)
        {
            //create an array with fixed value
            Array ar = new int[] { 2, 4, 3, 7, 9 };
            int x = int.Parse(Console.ReadLine());


            int res = RecuSearch2(ar, x);


            if (res == -1) Console.WriteLine(res);
            else Console.WriteLine(res + 1);
            
        }
    }
}
