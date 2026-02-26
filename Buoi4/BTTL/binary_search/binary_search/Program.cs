using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_search
{
    internal class Program
    {
        static bool binary_search(int[] ar, int l, int r, int x)
        {
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (ar[mid] == x)
                {
                    return true;
                }
                else if (ar[mid] > x)
                {
                    r = mid - 1;
                }
                else l = mid + 1;
            }
            return false;
        }


        static void Main(string[] args)
        {
            int[] ar = { 8, 5, 10, 2, 4, 3, 1, 7, 6, 9 };
            Array.Sort(ar);


            int x = int.Parse(Console.ReadLine());
            Console.WriteLine(binary_search(ar, 0, ar.Length - 1, x));
        }
    }
}
