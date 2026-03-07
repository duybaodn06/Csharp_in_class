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
                bool check = true;
                for (int j = 0; j < ar.Length - i - 1; j++)
                {
                    if (ar[j] > ar[j + 1])
                    {
                        int temp = ar[j];
                        ar[j] = ar[j + 1];
                        ar[j + 1] = temp;
                        check = false;
                    }
                }
                if (check) break;
            }
        }

        static void Main(string[] args)
        {


            int[] ar = new int[10000];
            int[] ar2 = new int[10000];
            int[] ar3 = new int[10000];
            int times = 100;

            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                ar[i] = rnd.Next(1,1000);
            }
            for (int i = 0; i < 10000; i++)
            {
                ar2[i] = 10000 - i;
            }
            for (int i = 0; i < 10000; i++)
            {
                ar3[i] = i;
            }



            Timing t = new Timing();
            
            TimeSpan totalTime = new TimeSpan(0);
            TimeSpan totalTime2 = new TimeSpan(0);
            TimeSpan totalTime3 = new TimeSpan(0);
            for (int i = 0; i < times; i++)
            {
                int[] tempArray = (int[])ar.Clone();
                t.startTime();
                bubble_sort(tempArray);
                t.StopTime();
                totalTime += t.Result();
            }
            for (int i = 0; i < times; i++)
            {
                int[] tempArray = (int[])ar2.Clone();
                t.startTime();
                bubble_sort(tempArray);
                t.StopTime();
                totalTime2 += t.Result();
            }
            int count3 = 0;
            for (int i = 0; i < times; i++)
            {
                t.startTime();
                bubble_sort(ar3);
                t.StopTime();
                if (t.Result().TotalMilliseconds == 0) count3 ++;
                else totalTime3 += t.Result();
            }
            
            


            Console.WriteLine($"Bubble sort truong hop tot nhat: {totalTime3.TotalMilliseconds / (times - count3)} ms");
            Console.WriteLine($"Bubble sort truong hop trung binh: {totalTime.TotalMilliseconds / times} ms");
            Console.WriteLine($"Bubble sort truong hop te nhat: {totalTime2.TotalMilliseconds / times} ms");

        }
    }
}

