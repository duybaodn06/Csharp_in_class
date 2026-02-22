using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heapsort
{
    internal class Program
    {
        static void heapify(int[] a, int n, int i)
        {
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int largest = i;
            if (l < n && a[l] > a[largest])
            {
                largest = l;
            }
            if (r < n && a[r] > a[largest])
            {
                largest = r;
            }
            if (largest != i)
            {
                (a[i], a[largest]) = (a[largest], a[i]);
                heapify(a, n, largest);
            }
        }

        static void heap_sort(int[] a, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heapify(a, n, i);
            }
            for (int i = n - 1; i > 0; i--)
            {
                (a[0], a[i]) = (a[i], a[0]);
                heapify(a, i, 0);
            }
        }

        static void Main(string[] args)
        {
            int[] a = { 9, 4, 3, 6, 8, 10, 7, 1, 2, 5 };
            heap_sort(a, 10);
            foreach (int i in a)
            {
                Console.Write(i + " ");
            }
        }
    }
}
