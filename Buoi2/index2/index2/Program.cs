using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
struct SinhVien 
{
    public string Id;
    public string Hoten;
    public float Gpa;
}

namespace index2
{
    internal class Program
    {
        static Array arrsv;
        static List<SinhVien> lsv;
        static ArrayList alsv;

        static void init()
        {
            arrsv = Array.CreateInstance(typeof(SinhVien), 100);
            lsv = new List<SinhVien>();
            alsv = new ArrayList();
        }

        static T SearchByGPA<T>(float a, float b)
        {
            if (typeof(T) == typeof(Array))
            {
                Array temp = Array.CreateInstance(typeof(SinhVien), 100);
                int index = 0;
                foreach (SinhVien x in arrsv){
                    if (x.Gpa>= a && x.Gpa <= b)
                    {
                        temp.SetValue(x, index++);
                    }
                }
                return (dynamic)temp;
            }
            else if (typeof(T) == typeof(List<SinhVien>))
            {
                List<SinhVien> temp = new List<SinhVien>();
                foreach (SinhVien x in lsv)
                {
                    if (x.Gpa >=a && x.Gpa <= b)
                    {
                        temp.Add(x);
                    }
                }
                return (dynamic)temp;

            }
            else if (typeof(T) == typeof(ArrayList))
            {
                ArrayList temp = new ArrayList();
                foreach (SinhVien x in alsv)
                {
                    if (x.Gpa >= a && x.Gpa <= b)
                    {
                        temp.Add(x);
                    }
                }
                return (dynamic)temp;

                //ArrayList temp = new ArrayList();
                //for (int i = 0; i < alsv.Count; i++)
                //{

                //    if (alsv.Gpa >= a && alsv[i].Gpa <= b)
                //    {

                //    }
                //}
                //return (dynamic)temp;

            }
            else return (dynamic)null;
        }

        static void Main(string[] args)
        {
            SinhVien sv1;
            sv1.Id = "ST001";
            sv1.Hoten = "Nguyen A";
            sv1.Gpa =  7.5f;

            SinhVien sv2;
            sv2.Id = "ST002";
            sv2.Hoten = "Nguyen B";
            sv2.Gpa = 8.0f;


            //Khoi tao dssv?
            arrsv.SetValue(sv1, 0);
            arrsv.SetValue(sv2, 1);
            lsv.Add(sv1); lsv.Add(sv2);
            alsv.Add(sv1); alsv.Add(sv2);

            Array arrresult = SearchByGPA<Array>(7f, 9f);
            List<SinhVien> lresult = SearchByGPA<List<SinhVien>>(7f, 9f);
            ArrayList alresult = SearchByGPA<ArrayList>(7f, 9f);
        }
    }
}
