using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Timing
{
    TimeSpan startingTime;
    TimeSpan duration;
    public Timing()
    {
        startingTime = new TimeSpan(0);
        duration = new TimeSpan(0);
    }
    public void StopTime()
    {
        duration =
        Process.GetCurrentProcess().Threads[0].
        UserProcessorTime.
        Subtract(startingTime);
    }
    public void startTime()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        startingTime =
        Process.GetCurrentProcess().Threads[0].
        UserProcessorTime;
    }
    public TimeSpan Result()
    {
        return duration;
    }
}

namespace timing_bubble
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
            //input
            Console.Write("Nhap so phan tu cua mang: ");
            int n = int.Parse(Console.ReadLine());

            int times = 1000;
            //tao mang random
            int[] ar = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                ar[i] = rnd.Next();
            }

            //bat dau do thoi gian
            Timing t = new Timing();
            t.startTime();
            for (int i = 0; i < times; i++) 
            {
                //clone: O(N)
                bubble_sort((int[])ar.Clone());
            }
            t.StopTime();
            //ket thuc do thoi gian

            //in ket qua ra man hinh
            Console.WriteLine($"Bubble sort mang co {n} phan tu mat {t.Result().TotalMilliseconds / times} ms");
        }
    }
}
