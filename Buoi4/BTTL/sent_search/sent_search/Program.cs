using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace sent_search
{
    internal class Program
    {
        static int SentSearch(int[] ar, int x)
        {
            if (x == ar[ar.Length -1]) return ar.Length - 1;
            int temp = ar[ar.Length-1];
            ar[ar.Length - 1] = x;
            int i = 0;
            while (x != ar[i]) i++;
            if (i < ar.Length - 1) return i;
            else return -1;
            
        }

        static void Main(string[] args)
        {
            int[] ar = { 3, 5, 1, 7, 9, 10, 8, 6, 2, 4 };
            int x = int.Parse(Console.ReadLine());

            int res = SentSearch(ar, x);
            if (res == -1)
            {
                Console.WriteLine(res);
            }
            else Console.WriteLine(res + 1);
        }
    }
}
