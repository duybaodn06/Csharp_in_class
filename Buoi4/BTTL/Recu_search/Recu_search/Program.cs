using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recu_search
{
    internal class Program
    {
        static int RecuSearch(int[] ar, int index, int val)
        {
            if (index >= ar.Length) return -1;
            if (ar[index] == val) return index;
            else return RecuSearch(ar,index + 1, val);
        }

        static void Main(string[] args)
        {
            int[] ar = { 8, 5, 10, 2, 4, 3, 1, 7, 6, 9 };
            int x = int.Parse(Console.ReadLine());
            int res = RecuSearch(ar, 0, x);
            if (res == -1) Console.WriteLine(res);
            else Console.WriteLine(res + 1);
        }
    }
}
