using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
struct SinhVien
{
    public string id;
    public string name;
    public float gpa;
}


namespace search_and_sort
{
    internal class Program
    {
        static Array arsv;
        static List<SinhVien> lsv;
        static ArrayList alsv;

        static void init()
        {
            arsv = Array.CreateInstance(typeof(SinhVien), 10);
            lsv = new List<SinhVien>();
            alsv = new ArrayList();
        }

        //Search
        static T SearchByGpa<T>(float from, float to)
        {
            if (typeof(T) == typeof(Array))
            {
                Array temp = Array.CreateInstance(typeof(SinhVien), 10);
                int count = 0;
                for (int i = 0; i < arsv.GetLength(0); i++)
                {
                    SinhVien t = (SinhVien)arsv.GetValue(i);
                    if (t.id != null && t.gpa >= from && t.gpa <= to)
                    {
                        temp.SetValue(t, count);
                        count++;
                    }
                }
                return (dynamic)temp;
            }
            else if (typeof(T) == typeof(List<SinhVien>))
            {
                List<SinhVien> temp = new List<SinhVien>();
                foreach (SinhVien x in lsv)
                {
                    if (x.gpa >= from && x.gpa <= to)
                    {
                        temp.Add(x);
                    }
                }
                return (dynamic)temp;
            }
            else
            {
                ArrayList temp = new ArrayList();
                foreach (SinhVien x in alsv)
                {
                    if (x.gpa >= from && x.gpa <= to)
                    {
                        temp.Add(x);
                    }
                }
                return (dynamic)temp;
            }
            return (dynamic)null;
        }
        //end of search



        //sort desc
        static T SortByGpa<T>()
        {
            //bubble sort

            if (typeof(T) == typeof(Array))
            {
                //create clone 
                Array temp = (Array)arsv.Clone();
                int n = temp.GetLength(0);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        SinhVien sv1 = (SinhVien)temp.GetValue(j);
                        SinhVien sv2 = (SinhVien)temp.GetValue(j + 1);
                        if (sv1.id == null && sv2.id != null)
                        {
                            temp.SetValue(sv2, j);
                            temp.SetValue(sv1, j + 1);
                        }
                        if (sv1.id == null || sv2.id == null)
                        {
                            continue;
                        }
                        if (sv1.gpa < sv2.gpa)
                        {
                            temp.SetValue(sv2, j);
                            temp.SetValue(sv1, j + 1);
                        }
                    }
                }
                return (dynamic)temp;
            }
            else if (typeof(T) == typeof(List<SinhVien>))
            {
                //selection sort
                List<SinhVien> temp = new List<SinhVien>(lsv);
                for (int i = 0; i < temp.Count() - 1; i++)
                {
                    float max = temp[i].gpa;
                    int index = i;
                    for (int j = 1 + i; j < temp.Count(); j++)
                    {
                        if (max < temp[j].gpa)
                        {
                            max = temp[j].gpa;
                            index = j;
                        }
                    }
                    (temp[index], temp[i]) = (temp[i], temp[index]);
                }
                return (dynamic)temp;
            }
            else if (typeof(T) == typeof(ArrayList))
            {
                ArrayList temp = (ArrayList)alsv.Clone();
                for (int i = 0; i < temp.Count - 1; i++)
                {
                    float max = ((SinhVien)temp[i]).gpa;
                    int index = i;
                    for (int j = 1 + i; j < temp.Count; j++)
                    {
                        if (max < ((SinhVien)temp[j]).gpa)
                        {
                            max = ((SinhVien)temp[j]).gpa;
                            index = j;
                        }
                    }
                    (temp[index], temp[i]) = (temp[i], temp[index]);
                }
                return (dynamic)temp;
            }
            return (dynamic)null;
        }
        //end of sort


        //start seaching
        static void start_searching(int times, Timing t)
        {
            //searching
            t.startTime();
            for (int i = 0; i < times; i++)
            {
                Array ares = SearchByGpa<Array>(7f, 9f);
            }
            t.StopTime();
            Console.WriteLine($"Searching {times} times with Array in {t.Result().TotalMilliseconds} ms");

            t.startTime();
            for (int i = 0; i < times; i++)
            {
                List<SinhVien> lres = SearchByGpa<List<SinhVien>>(7f, 9f);
            }
            
            t.StopTime();
            Console.WriteLine($"Searching {times} times with List in {t.Result().TotalMilliseconds} ms");

            t.startTime();
            for (int i = 0; i < times; i++)
            {
                ArrayList alres = SearchByGpa<ArrayList>(7f, 9f);
            }
            t.StopTime();
            Console.WriteLine($"Searching {times} times with ArrayList in {t.Result().TotalMilliseconds} ms");
        }
        //end searching


        //start sorting
        static void start_sorting(int times, Timing t)
        {
            //sorting
            t.startTime();
            for (int i = 0; i < times; i++)
            {
                Array sortasv = SortByGpa<Array>();
            }
            t.StopTime();
            Console.WriteLine($"Sorting {times} times with Array in {t.Result().TotalMilliseconds} ms");

            t.startTime();
            for (int i = 0; i < times; i++)
            {
                List<SinhVien> sortlsv = SortByGpa<List<SinhVien>>();
            }
            t.StopTime();
            Console.WriteLine($"Sorting {times} times with List in {t.Result().TotalMilliseconds} ms");

            t.startTime();
            for (int i = 0; i < times; i++)
            {
                ArrayList sortalsv = SortByGpa<ArrayList>();
            }
            t.StopTime();
            Console.WriteLine($"Sorting {times} times with ArrayList in {t.Result().TotalMilliseconds} ms");

        }
        //end sorting


        //adding 
        static void adding()
        {
            SinhVien sv1;
            sv1.id = "SV001";
            sv1.name = "Nguyen A";
            sv1.gpa = 7.5f;
            SinhVien sv2;
            sv2.id = "SV002";
            sv2.name = "Le B";
            sv2.gpa = 8.5f;
            SinhVien sv3;
            sv3.id = "SV003";
            sv3.name = "Tran C";
            sv3.gpa = 6.5f;

            arsv.SetValue(sv1, 0);
            arsv.SetValue(sv2, 1);
            arsv.SetValue(sv3, 2);
            lsv.Add(sv1); lsv.Add(sv2); lsv.Add(sv3);
            alsv.Add(sv1); alsv.Add(sv2); alsv.Add(sv3);
        }
        //end adding


        static void Main(string[] args)
        {
            init();
            adding();

            int times = 1000000;
            Timing t = new Timing();

            //timing
            start_searching(times,t);
            start_sorting(times, t);
        }
    }
}
