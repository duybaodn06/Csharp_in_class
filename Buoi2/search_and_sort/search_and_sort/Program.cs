using MySql.Data.MySqlClient;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
            arsv = Array.CreateInstance(typeof(SinhVien), 100);
            lsv = new List<SinhVien>();
            alsv = new ArrayList();
        }

        //Search
        static T SearchByGpa<T>(float from, float to)
        {
            if (typeof(T) == typeof(Array))
            {
                Array temp = Array.CreateInstance(typeof(SinhVien), 100);
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
                for (int i = 0; i < lsv.Count() - 1; i++)
                {
                    float max = lsv[i].gpa;
                    int index = i;
                    for (int j = 1 + i; j < lsv.Count(); j++)
                    {
                        if (max <  lsv[j].gpa)
                        {
                            max = lsv[j].gpa;
                            index = j;
                        }
                    }
                    (lsv[index], lsv[i]) = (lsv[i], lsv[index]);
                }
                return (dynamic)lsv;
            }
            else if (typeof(T) == typeof(ArrayList))
            {
                for (int i = 0; i < alsv.Count - 1; i++)
                {
                    float max = ((SinhVien)alsv[i]).gpa;
                    int index = i;
                    for (int j = 1 + i; j < alsv.Count; j++)
                    {
                        if (max < ((SinhVien)alsv[j]).gpa)
                        {
                            max = ((SinhVien)alsv[j]).gpa;
                            index = j;
                        }
                    }
                    (alsv[index], alsv[i]) = (alsv[i], alsv[index]);
                }
                return (dynamic)alsv;
            }
            return (dynamic)null;
        }
        //end of sort


        //start seaching
        static void start_searching()
        {
            //searching
            Array ares = SearchByGpa<Array>(7f, 9f);
            List<SinhVien> lres = SearchByGpa<List<SinhVien>>(7f, 9f);
            ArrayList alres = SearchByGpa<ArrayList>(7f, 9f);
            
            //printing
            for (int i = 0; i < ares.GetLength(0); i++)
            {
                if (((SinhVien)ares.GetValue(i)).id == null) continue;
                Console.WriteLine(((SinhVien)ares.GetValue(i)).id);
                Console.WriteLine(((SinhVien)ares.GetValue(i)).name);
                Console.WriteLine(((SinhVien)ares.GetValue(i)).gpa);
            }
            Console.WriteLine();

            foreach (SinhVien x in lres)
            {
                Console.WriteLine(x.id);
                Console.WriteLine(x.name);
                Console.WriteLine(x.gpa);
            }
            Console.WriteLine();

            foreach (SinhVien x in alres)
            {
                Console.WriteLine(x.id);
                Console.WriteLine(x.name);
                Console.WriteLine(x.gpa);
            }
        }
        //end searching


        //start sorting
        static void start_sorting()
        {
            //sorting
            Array sortasv = SortByGpa<Array>();
            List<SinhVien> sortlsv = SortByGpa<List<SinhVien>>();
            ArrayList sortalsv = SortByGpa<ArrayList>();


            //printing
            foreach (SinhVien x in sortasv)
            {
                if (x.id != null)
                {
                    Console.WriteLine(x.id);
                    Console.WriteLine(x.name);
                    Console.WriteLine(x.gpa);
                }
            }
            Console.WriteLine();
            foreach (SinhVien x in sortlsv)
            {
                Console.WriteLine(x.id);
                Console.WriteLine(x.name);
                Console.WriteLine(x.gpa);
            }
            Console.WriteLine();
            foreach (SinhVien x in sortalsv)
            {
                Console.WriteLine(x.id);
                Console.WriteLine(x.name);
                Console.WriteLine(x.gpa);
            }
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

            //print result 
            //start_searching();
            start_sorting();
        }
    }
}
