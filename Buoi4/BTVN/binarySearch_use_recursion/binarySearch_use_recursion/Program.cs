using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearch_use_recursion
{
    internal class Program
    {

        static int BiSearch(int[] ar, int l, int r, int x)
        {
            if (l > r) return -1;
            int mid = (l + r) / 2;
            if (ar[mid] == x) return 1;
            else if (ar[mid] > x) return BiSearch(ar, l, mid - 1, x);
            else return BiSearch(ar, mid +1 , r, x);
        }

        static void Main(string[] args)
        {
            int[] ar = { 8, 5, 10, 2, 4, 3, 1, 7, 6, 9 };
            Array.Sort(ar);

            int x = int.Parse(Console.ReadLine());
            if (BiSearch(ar, 0, ar.Length - 1, x) == 1) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
