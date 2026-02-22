using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace quicksort
{
    internal class Program
    {
        static void quick_sort(int[] ar,int low,int high)
        {
            if (low < high)
            {
                int pi = partition(ar, low,high);
                quick_sort(ar, low, pi - 1);
                quick_sort(ar, pi + 1, high);
            }
        }
        static int partition(int[] ar, int low,int high)
        {
            int pivot = ar[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (ar[j] <= pivot)
                {
                    i++;
                    (ar[i], ar[j]) = (ar[j], ar[i]);
                }
            }
            i++;
            (ar[i], ar[high]) = (ar[high], ar[i]);
            return i;
        }

        static void Main(string[] args)
        {
            int[] ar = { 20, 2, 7, 12, 15, 1, 6, 8 ,9};
            quick_sort(ar, 0 , ar.Length - 1);
            foreach (int i in ar)
            {
                Console.Write(i + " ");
            }
        }
    }
}
