using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seq_search
{
    internal class Program
    {
        static int SeqSearch(int[] ar,int x)
        {
            int i = 0;
            while (i < ar.Length)
            {
                if (ar[i] == x) return i;
                else i+=1;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] ar = { 8, 5, 10, 2, 4, 3, 1, 7, 6, 9 };
            int x = int.Parse(Console.ReadLine());
            int res = SeqSearch(ar, x);

            if (res == -1) Console.WriteLine(res);
            else Console.WriteLine(res + 1);
            
        }
    }
}
