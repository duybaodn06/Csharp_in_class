using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace copy
{
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
            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startingTime);
        }
        public void startTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    internal class Program
    {
        static T reverse<T>(ref T n)
        {
            // == O(1)
            if (typeof(T) == typeof(int))
            {
                dynamic res = 0;
                dynamic copy = n;
                while (copy > 0)
                {
                    int a = copy % 10;
                    res = res * 10 + a;
                    copy = copy / 10;
                }
                return res;
            }
            //O(N^2)
            else if (typeof(T) == typeof(string))
            {
                dynamic res = "";
                foreach (char x in (dynamic)n)
                {
                    res = x + res;
                }
                return res;
            }
            //O(N)
            else if (typeof(T).IsArray)
            {
                dynamic a = n;
                Array.Reverse(a);
                return (dynamic)a;
            }
            return (dynamic)0;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int a = 123456789;
            string b = "XinChaoCacBanSinhVienUEH"; 
            int[] c = new int[1000]; 
            for (int i = 0; i < c.Length; i++) c[i] = i; // O(n) 

            int times = 1000000;
            Timing t = new Timing();
            t.startTime();     
            for (int i = 0; i < times; i++)
            {
                reverse<int>(ref a);
            }
            t.StopTime();      
            Console.WriteLine($"Thời gian đảo Int {times} lan: {t.Result().TotalMilliseconds} ms");


            t.startTime();
            for (int i = 0; i < times; i++)
            {
                reverse<string>(ref b);
            }
            t.StopTime();
            Console.WriteLine($"Thời gian đảo String {times} lan: {t.Result().TotalMilliseconds} ms");


            
            t.startTime();
            for (int i = 0; i < times; i++)
            {
                reverse<int[]>(ref c);
            }
            t.StopTime();
            Console.WriteLine($"Thời gian đảo Array với {c.Length} phần tử {times} lan: {t.Result().TotalMilliseconds} ms");

        }
    }
}
