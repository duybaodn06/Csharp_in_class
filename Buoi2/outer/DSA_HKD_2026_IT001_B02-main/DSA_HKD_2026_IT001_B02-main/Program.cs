using System.Collections;

struct SinhVien
{
    public string ID;
    public string Hoten;
    public float Gpa;
}
class Program
{
    static Array arrsv;
    static List<SinhVien> lsv;
    static ArrayList alsv;

    static void KhoiTaoDSSV()
    {
        arrsv = Array.CreateInstance(
            typeof(SinhVien), 100
        );
        lsv = new List<SinhVien>();
        alsv = new ArrayList();
    }
    static T SearchByGPA<T>(float from, float to)
    {
        if (typeof(T) == typeof(Array))
        {
            Array temp = Array.CreateInstance(
                typeof(SinhVien), arrsv.GetLength(0)
            );
            int x = 0;
            for (int i = 0; i < arrsv.GetLength(0); i++){
                SinhVien t = (SinhVien)arrsv.GetValue(i);
                if (t.Gpa >= from && t.Gpa <= to){
                    temp.SetValue(t, x++);
                }
                return (dynamic)temp;
            }
        }
        else if (typeof(T) == typeof(List<SinhVien>))
        {
            List<SinhVien>kq = new List<SinhVien>();
            foreach (SinhVien sv in lsv)
            {
                if (sv.Gpa >= from && sv.Gpa <= to)
                {
                     kq.Add(sv);
                }  
            }
            return (dynamic)kq;
        }
        else if (typeof(T) == typeof(ArrayList))
        {
            ArrayList kq = new ArrayList();
            foreach (SinhVien sv in alsv)
            {
                if (sv.Gpa >= from && sv.Gpa <= to)
                {
                     kq.Add(sv);
                }  
            }
            return (dynamic)kq;
        }
        return (dynamic)0;
    }
    static void Main(string[] args)
    {
        Console.Clear();

        SinhVien sv1;
        sv1.ID = "SV001";
        sv1.Hoten = "Nguyen A";
        sv1.Gpa = 7.5f;
        SinhVien sv2;
        sv2.ID = "SV002";
        sv2.Hoten = "Le B";
        sv2.Gpa = 8.5f;

        KhoiTaoDSSV();
        arrsv.SetValue(sv1, 0);
        arrsv.SetValue(sv2, 1);
        lsv.Add(sv1); lsv.Add(sv2);
        alsv.Add(sv1); alsv.Add(sv2);

        Array arresult = SearchByGPA<Array>(7f, 9f);
        List<SinhVien> lresult = SearchByGPA<List<SinhVien>>(7f, 9f);
        ArrayList alresult = SearchByGPA<ArrayList>(7f, 9f);
        
        foreach (SinhVien s in arresult)
        {
            Console.WriteLine(s.ID);
        }
        
        //Array arr1 = Array.CreateInstance(typeof(int), 4);
        //Random rand = new Random();

        //for(int i=0; i<arr1.GetLength(0); i++)
        //    arr1.SetValue(rand.Next(0, 10), i);
        //foreach(int value in arr1)
        //    Console.Write(value + ", ");

        //int sum = 0;
        //for(int i=0; i<arr1.GetLength(0); i++)
        //    sum = sum + (int)arr1.GetValue(i);

        //Khai báo mảng 2 chiều kích thước 3x4, chỉ số từ 0 và 1
        //Array arr2 = Array.CreateInstance(
        //                typeof(int),
        //                new int[]{3, 4},
        //                new int[]{0, 1}
        //             );
        //for(int i=arr2.GetLowerBound(0); 
        //            i<=arr2.GetUpperBound(0); i++)
        //    for(int j=arr2.GetLowerBound(1); 
        //                j<=arr2.GetUpperBound(1); j++)
        //        arr2.SetValue(rand.Next(0, 10), i, j);
        //int sum2 = 0;
        //for(int i=arr2.GetLowerBound(0); 
        //            i<=arr2.GetUpperBound(0); i++)
        //    for(int j=arr2.GetLowerBound(1); 
        //                j<=arr2.GetUpperBound(1); j++)
        //        sum2+=(int)arr2.GetValue(i, j);

        //Console.WriteLine("\n=============");
        //Array.Sort(arr1);
        //for(int i=arr2.GetLowerBound(0); 
        //            i<=arr2.GetUpperBound(0); i++){
        //    Console.WriteLine((int)arr1.GetValue(i));
        //}
        
    }
}