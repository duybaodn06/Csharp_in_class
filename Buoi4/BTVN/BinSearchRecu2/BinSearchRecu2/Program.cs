using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinSearchRecu2
{
    internal class Program
    {
        static bool binary_search(Array ar, int x)
        {
            return binary_search_action(ar, x, 0, ar.GetLength(0) - 1);
        }

        static bool binary_search_action(Array ar, int x , int l , int r)
        {
            if (l > r) return false;
            int mid = (l + r) / 2;

            if ((int)ar.GetValue(mid) == x) return true;
            else if ((int)ar.GetValue(mid) < x) return binary_search_action(ar, x, mid + 1, r);
            else return binary_search_action(ar, x, l, mid - 1);
            
            
            
        }


        static void Main(string[] args)
        {
            Array ar = new int[] { 2, 4, 3, 7, 9 };
            int x = int.Parse(Console.ReadLine());

            Array.Sort(ar);
            bool check = binary_search(ar, x);
            if (check) Console.WriteLine("YES");
            else Console.WriteLine("NO");

        }
    }
}
