using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mergesort
{
    internal class Program
    {
        static void merge(int[] ar, int l, int mid, int r )
        {
            //create 2 array left and right
            int[] lar = new int[mid - l + 1];
            int[] rar = new int[r - mid];

            //copy
            for (int t = 0; t < lar.GetLength(0); t++)
            {
                lar[t] = ar[l + t];
            }
            for (int t = 0; t < rar.GetLength(0); t++)
            {
                rar[t] = ar[mid + t + 1];
            }

            //create index i j for each array and index k for merging
            int i, j; i = j = 0;
            int k = l;

            //use merging algorithms
            while (i < lar.GetLength(0) && j < rar.GetLength(0))
            {
                if (lar[i] <= rar[j])
                {
                    ar[k] = lar[i];
                    i++;
                }
                else
                {
                    ar[k] = rar[j];
                    j++;
                }
                k++;
            }

            while (i < lar.GetLength(0))
            {
                ar[k] = lar[i]; 
                i++; k++;
            }

            while (j < rar.GetLength(0))
            {
                ar[k] = rar[j];
                j++; k++;
            }
        }

        static void mergesort(int[] ar, int l, int r)
        {
            if (l < r)
            {
                //split into 2 
                int mid = (l + r) / 2;

                //use recursion to continue spliting
                mergesort(ar, l, mid);
                mergesort(ar, mid + 1, r);

                //after spliting, merging each array
                merge(ar, l, mid, r);
            }
        }
        static void Main(string[] args)
        {
            int[] ar = { 2, 8, 5, 3, 9, 4, 1, 7 };
            mergesort(ar, 0, ar.GetLength(0) - 1);
            foreach (int i in ar)
            {
                Console.Write(i + " ");
            }
        }
    }
}
