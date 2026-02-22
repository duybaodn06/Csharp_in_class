using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bubble_install
{
    internal class Program
    {
        static void bubble_sort(int[] ar)
        {
            for (int i = 0; i < ar.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < ar.Length - i - 1; j++)
                {
                    if (ar[j] > ar[j + 1])
                    {
                        (ar[j], ar[j + 1]) = (ar[j + 1], ar[j]);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] ar = new int[n];
            for (int i = 0; i < n; i++)
            {
                ar[i] = int.Parse(Console.ReadLine());
            }
            bubble_sort(ar);
            
            foreach (int i in ar)
            {
                Console.Write(i + " ");
            }
        }
    }
}
